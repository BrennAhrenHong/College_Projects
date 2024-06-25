# Import library
from time import sleep, strftime
from tkinter import *
from tkinter import ttk
import tkinter as tkk
from datetime import *
from tkinter.font import BOLD
from turtle import width
from picamera import PiCamera
from time import sleep
import I2C_LCD_driver
import RPi.GPIO as GPIO
import time
import re
import sched
from threading import Timer
import telepot
import os
from PIL import Image
import sys

#TODO
#Make LCD Text Scrollable
#Annoy user until they confirm person at the door
#Add standby text when someone is detected





# Bot token
bot = telepot.Bot('5270546376:AAGtyhiWB10O-3Z4oJeG8MyatuumuoOlskk')

# Use GPIO
GPIO.setwarnings(False) # Suppress warnings
GPIO.setmode(GPIO.BCM) # Use "Gpio" pin numbering


# Pin Definitions
GPIO_TRIGGER = 18
GPIO_ECHO = 24
alarm_pin = 6

GPIO.setup(alarm_pin, GPIO.OUT) # Set LED pin as output
# Variable Pre-Declaration
count = 0
photoCount = 0
timer = 0
tmpData = [ ["", "", ""]   ]
isUserTypingMsg = False
isTelegramOnline = False
pauseTime = 0
isParameterBeingAdjusted = False

framebuffer = [
            '',
            '',
            ]

sleepStartTime = time.time()
sleepEndTime = time.time()

proximityStartTime = time.time()
proximityEndTime = time.time()

sleepTimer = 5
activationRange = 40
pauseTimeParameter = 5

isAlarm = False
setSched = sched.scheduler(time.time, time.sleep)
#Setup
GPIO.setup(GPIO_TRIGGER, GPIO.OUT)
GPIO.setup(GPIO_ECHO, GPIO.IN)
myLcd = I2C_LCD_driver.lcd()

def cmdTakePhoto():
    global photoCount

    photoCount = photoCount + 1
    camera = PiCamera()
    camera.rotation = 180
    camera.resolution = (1024, 768)
    camera.start_preview()
    time.sleep(2)
    fileName = "pic" + str(photoCount) + ".jpg"
    camera.capture("./PiCameraGallery/" + fileName)
    camera.stop_preview()
    camera.close()

    addEvent()


def cmdPause():
    global pauseTime
    
    getSelection = str(dropPauseTimerClicked.get())
    selection = int(re.search(r'\d+', getSelection).group())
    
    pauseTime = time.time() + selection

    print(time.time())
    print(selection)
    print(pauseTime)
    print(pauseTime - time.time())

    lblCloseProximityDetectorStatus.config(text="Paused", foreground='blue')
    lblMotionDetectorStatus.config(text="Paused", foreground='blue')

def cmdSetPauseTime():
    global pauseTimeParameter
    
    getSelection = str(dropPauseTimerClicked.get())
    selection = int(re.search(r'\d+', getSelection).group())
    
    pauseTimeParameter = time.time() + selection

def cmdSleepTime():
    global sleepTimer    
    getSelection = str(dropSleepTimeClicked.get())
    selection = int(re.search(r'\d+', getSelection).group())
    
    sleepTimer = int(selection)   
    print (selection)
    
def activationDistance():
    global activationRange
    getSelection = str(dropActivationClicked.get())
    selection = int(re.search(r'\d+', getSelection).group())
    
    activationRange = selection
    cmdSleepTime()
    print (selection)

def cmdApply():
    cmdSetPauseTime()
    cmdSleepTime()
    activationDistance()


def cmdExit():
    # global
    sys.exit()


def cmdSend():  
    textMsg = textLcd.get(1.0, tkk.END+"-1c")
    
    myLcd.lcd_clear()
    myLcd.lcd_display_string(textMsg,1,1)
    
    textLcd.delete('1.0', END)
    
    prevTextLcd.config(state=NORMAL)
    prevTextLcd.delete('1.0',END)
    prevTextLcd.insert('1.0', textMsg)
    prevTextLcd.config(state=DISABLED)


def cmdSendFromTelegram(msg):

    myLcd.lcd_clear()
    myLcd.lcd_display_string(msg,1,1)
    
    prevTextLcd.config(state=NORMAL)
    prevTextLcd.delete('1.0',END)
    prevTextLcd.insert('1.0', msg)
    prevTextLcd.config(state=DISABLED)
    

'''
while True:
    dist = cmdCheckDistance()
    print("Measured Distance = %.1f cm" % dist)
    time.sleep(1)
'''

# Create the cmdMain window and its specifications
window = Tk()
window.title('GUI Monitor')
window.geometry("1024x450+400+100")

# Left Side Panel
lblTitle = Label(window, font=('Arial', 24))
lblTitle.place(x=50, y=10)
lblTitle.config(text="Door Notifier", foreground='blue')

lblMsgDisplay = Label(window, font=('Arial', 14, BOLD))
lblMsgDisplay.place(x=50, y=235)
lblMsgDisplay.config(text="LCD Message Display", foreground='blue')

textLcd = Text(window, height=3, width=23, border= 2)
textLcd.place(x=55, y=265)

lblPrevMsgDisplay = Label(window, font=('Arial', 14, BOLD))
lblPrevMsgDisplay.place(x=700, y=50)
lblPrevMsgDisplay.config(text="Previous Message", foreground='blue')

prevTextLcd = Text(window, height=3, width=23, border= 2)
prevTextLcd.place(x=700, y=75)
prevTextLcd.config(state=DISABLED)

btnSend = Button(window, text="Send", foreground='blue', height=1,
                 width=18, command=cmdSend)
btnSend.place(x=56, y=325)


btnPause = Button(window, text="Pause", foreground='blue', height=2,
                  width=20, command=cmdPause)
btnPause.place(x=50, y=60)

btnTakePhoto = Button(window, text="Take Photo", foreground='blue', height=2,
                      width=20, command=cmdTakePhoto)
btnTakePhoto.place(x=50, y=120)

btnExit = Button(window, text="Exit", foreground='blue', height=2,
                 width=20, command=cmdExit)
btnExit.place(x=50, y=180)

# Table
lblTitle = Label(window, font=('Arial', 24))
lblTitle.place(x=300, y=10)
lblTitle.config(text="Event Log", foreground='blue')


lblTimer = Label(window, font=('Arial', 24))
lblTimer.place(x=475, y=10)
lblTimer.config(text="00:00", foreground='Red')

lblTimer.config(text ="")




# date/time/photo name
myTree = ttk.Treeview(window)
myTree.place(x=300, y=50)


myTree['columns'] = ("Date", "Time", "Photo Name")


myTree.column("#0", width=0, stretch=NO)
myTree.column("Date", anchor=CENTER, width=100)
myTree.column("Time", anchor=CENTER, width=80)
myTree.column("Photo Name", anchor=W, width=200)

myTree.heading("#0", text="Label", anchor=W)
myTree.heading("Date", text="Date", anchor=CENTER)
myTree.heading("Time", text="Time", anchor=CENTER)
myTree.heading("Photo Name", text="Photo", anchor=W)


# Create striped row tags
myTree.tag_configure('oddrow', background="white")
myTree.tag_configure('evenrow', background="light blue")




# Add Data
def cmdAdd():
    global tmpData

    currentDate = datetime.now().strftime("%m/%d/%Y")
    currentTime = datetime.now().strftime("%H:%M")
    Data = [
        [currentDate, currentTime, "photo.jpg"]
    ]
    tmpData = Data
    cmdInsert()



def cmdInsert():
    global count

    for record in tmpData:
        if count % 2 == 0:
            myTree.insert(parent='', index='0', iid=count, text="", values=(
                record[0], record[1], record[2]), tags=('evenrow',))
        else:
            myTree.insert(parent='', index='0', iid=count, text="", values=(
                record[0], record[1], record[2]), tags=('oddrow',))

        count += 1



# Remove Data
def cmdSelectRecord():
    # Grab record number
    selected = myTree.focus()
    # Grab record values
    values = myTree.item(selected, 'values')

# Select Data
def clicker(e):
    cmdSelectRecord()
    
def cmdOpenPic():
    selected = myTree.focus()
    values = myTree.item(selected, 'values')
    treeArray = []
    
    
    if(values != None):
        for v in values:
            treeArray.append(v)
    
        
        picture = Image.open("/home/pi/Desktop/ProjectCode/PiCameraGallery/" + treeArray[2])
        picture.show()
    
def cmdSendPictureToTelegram():
    
        selected = myTree.focus()
        values = myTree.item(selected, 'values')
        treeArray = []
        for v in values:
            treeArray.append(v)        
        
        print (treeArray[2])
        bot.sendPhoto(1726351746, open("/home/pi/Desktop/ProjectCode/PiCameraGallery/" + treeArray[2],'rb'))
# Remove Selected Data
def remove_many():
    x = myTree.selection()
    for record in x:
        myTree.delete(record)


def cmdAlarm():
    global isAlarm
    
    GPIO.output(alarm_pin, GPIO.HIGH)
    sleep(0.20)
    GPIO.output(alarm_pin, GPIO.LOW)
    sleep(0.20)
    GPIO.output(alarm_pin, GPIO.HIGH)
    sleep(0.20)
    GPIO.output(alarm_pin, GPIO.LOW)
    sleep(0.20)
    GPIO.output(alarm_pin, GPIO.HIGH)
    sleep(0.20)
    GPIO.output(alarm_pin, GPIO.LOW)
    sleep(0.20)
    GPIO.output(alarm_pin, GPIO.HIGH)
    sleep(0.20)
    GPIO.output(alarm_pin, GPIO.LOW)
    sleep(0.20)
    GPIO.output(alarm_pin, GPIO.HIGH)
    sleep(0.20)
    GPIO.output(alarm_pin, GPIO.LOW)
    sleep(0.20)
    GPIO.output(alarm_pin, GPIO.HIGH)
    sleep(0.20)
    GPIO.output(alarm_pin, GPIO.LOW)
    sleep(0.20)
    GPIO.output(alarm_pin, GPIO.HIGH)
    sleep(0.20)
    GPIO.output(alarm_pin, GPIO.LOW)


btnAdd = Button(window, text="Apply", foreground='blue', height=2,
                width=10, command=cmdApply)
btnAdd.place(x=850, y=225)

#btnDelete = Button(window, text="Delete", foreground='blue', height=2,
                   #width=10, command=remove_many)
#btnDelete.place(x=700, y=225)

btnOpenPic = Button(window, text="Open Pic", foreground='blue', height=2,
                width=10, command=cmdOpenPic)
btnOpenPic.place(x=700, y=150)

btnSendTelegram = Button(window, text="Send Pic to User", foreground='blue', height=2,
                 width=10, command=cmdSendPictureToTelegram)
btnSendTelegram.place(x=700, y=225)

#Monitoring Status
lblSensorOutput = Label(window, font=('Arial', 14, 'bold'))
lblSensorOutput.place(x=300, y=280)
lblSensorOutput.config(text="Sensor Output", foreground='blue')

lblStatusOutput = Label(window, font=('Arial', 14, 'bold'))
lblStatusOutput.place(x=500, y=280)
lblStatusOutput.config(text="Status", foreground='blue')

#Sensor
lblMotionDetector = Label(window, font=('Arial', 12, 'bold'))
lblMotionDetector.place(x=300, y=320)
lblMotionDetector.config(text="Range Finder:", foreground='blue')

lblCloseProximityDetector = Label(window, font=('Arial', 12, 'bold'))
lblCloseProximityDetector.place(x=300, y=360)
lblCloseProximityDetector.config(text="Proximity Detector:", foreground='blue')

#lblPiCamera = Label(window, font=('Arial', 12, 'bold'))
#lblPiCamera.place(x=300, y=400)
#lblPiCamera.config(text="Pi Camera:", foreground='blue')

#Status
lblMotionDetectorStatus = Label(window, font=('Arial', 12, 'bold'))
lblMotionDetectorStatus.place(x=480, y=320)
lblMotionDetectorStatus.config(text="Standing By...", foreground='blue')

lblCloseProximityDetectorStatus = Label(window, font=('Arial', 12, 'bold'))
lblCloseProximityDetectorStatus.place(x=480, y=360)
lblCloseProximityDetectorStatus.config(text="Standing By...", foreground='blue')

#lblPiCameraStatus = Label(window, font=('Arial', 12, 'bold'))
#DlblPiCameraStatus.place(x=480, y=400)
#lblPiCameraStatus.config(text="Standing By...", foreground='blue')







#Settings
lblSensorSettings = Label(window, font=('Arial', 14, 'bold'))
lblSensorSettings.place(x=650, y=280)
lblSensorSettings.config(text="Sensor Output", foreground='blue')

lblParametersSettings = Label(window, font=('Arial', 14, 'bold'))
lblParametersSettings.place(x=850, y=280)
lblParametersSettings.config(text="Parameters", foreground='blue')

#Sensor
lblActivationDistanceSetting = Label(window, font=('Arial', 12, 'bold'))
lblActivationDistanceSetting.place(x=650, y=320)
lblActivationDistanceSetting.config(text="Activation Distance:", foreground='blue')

lblSleepTimeSetting = Label(window, font=('Arial', 12, 'bold'))
lblSleepTimeSetting.place(x=650, y=360)
lblSleepTimeSetting.config(text="Sleep Time:", foreground='blue')

lblSystemPauseTimerSetting = Label(window, font=('Arial', 12, 'bold'))
lblSystemPauseTimerSetting.place(x=650, y=400)
lblSystemPauseTimerSetting.config(text="System Pause Timer:", foreground='blue')


dropActivationDistanceOptions = [
    "15 cm",
    "30 cm",
    "40 cm",
    "50 cm",
    "75 cm",
    "100 cm",
    "200 cm"
]

dropSleepTimeOptions = [
    "5 secs",
    "10 secs",
    "15 secs",
    "30 secs",
    "60 secs"
]

dropPauseTimerOptions = [
    "5 seconds",
    "10 seconds",
    "30 seconds",
    "60 seconds",
    "120 seconds",
    "300 seconds",
    "600 seconds"
]


dropActivationClicked = StringVar()
dropActivationClicked.set("40 cm")

dropSleepTimeClicked = StringVar()
dropSleepTimeClicked.set("5 secs")

dropPauseTimerClicked = StringVar()
dropPauseTimerClicked.set("5 secs")

#Parameters
#lblActivationDistanceParameter = Label(window, font=('Arial', 12, 'bold'))
dropActivationDistance = OptionMenu(window, dropActivationClicked, *dropActivationDistanceOptions)
dropActivationDistance.config(width=10)
dropActivationDistance.place(x=850,y=320)

#lblSleepTimeParameter = Label(window, font=('Arial', 12, 'bold'))
dropSleepTime = OptionMenu(window, dropSleepTimeClicked, *dropSleepTimeOptions)
dropSleepTime.config(width=10)
dropSleepTime.place(x=850,y=360)

#lblSystemPauseTimerParameter = Label(window, font=('Arial', 12, 'bold'))
dropPauseTimer = OptionMenu(window, dropPauseTimerClicked, *dropPauseTimerOptions)
dropPauseTimer.config(width=10)
dropPauseTimer.place(x=850,y=400)



def cmdTakePhotoWhenDetected():
    global photoCount
    
    photoCount = photoCount + 1
    camera = PiCamera()
    camera.rotation = 180
    camera.resolution = (1024, 768)
    camera.start_preview()
    time.sleep(2)
    fileName = "pic" + str(photoCount) + ".jpg"
    camera.capture("./PiCameraGallery/" + fileName)
    camera.stop_preview()
    camera.close()
    
    addEvent()
        
        
def addEvent():
    global tmpData
    global photoCount

    currentDate = datetime.now().strftime("%m/%d/%Y")
    currentTime = datetime.now().strftime("%H:%M")
    
    fileName = "pic" + str(photoCount) + ".jpg"
    
    Data = [
        [currentDate, currentTime, fileName]
    ]
    tmpData = Data
    cmdInsert()


#Main
def cmdMain():
    global sleepEndTime
    global pauseTime
    
    if(sleepEndTime < time.time()) and pauseTime < time.time():
        pauseTime = 0
        cmdCheckDistance()
    else: 
        window.after(15,cmdMain)
        
def cmdCheckProximity():
    # set Trigger to HIGH
    global lblCloseProximityDetectorStatus
    global proximityEndTime
    global pauseTime

    

    if(pauseTime > time.time()):
        proximityEndTime = 0
        window.after(15, cmdMain)
    
    GPIO.output(GPIO_TRIGGER, True)

    # set Trigger after 0.01ms to LOW
    time.sleep(0.00001)
    GPIO.output(GPIO_TRIGGER, False)

    StartTime = time.time()
    StopTime = time.time()

    # save StartTime
    while GPIO.input(GPIO_ECHO) == 0:
        StartTime = time.time()

    # save time of arrival
    while GPIO.input(GPIO_ECHO) == 1:
        StopTime = time.time()

    # time difference between start and arrival
    TimeElapsed = StopTime - StartTime
    # multiply with the sonic speed (34300 cm/s)
    # and divide by 2, because there and back
    distance = (TimeElapsed * 34300) / 2
    

    # if below threshold, take a photo and start detecting close range
    if distance <= 30:
        cmdAlarm()
        cmdSendFromTelegram("Please Wait...")
        proximityEndTime = time.time()
        
        if(isTelegramOnline):
            cmdAlertTelegramUser()
            
        cmdSleepTimer()
    else:
        lblMotionDetectorStatus.config(text=str(round(distance,2))+ " cm", foreground='green')
    

    if proximityEndTime > time.time():       
        window.after(15,  cmdCheckProximity)
    else:
        lblMotionDetectorStatus.config(text="Standing By...", foreground='blue')
        lblCloseProximityDetectorStatus.config(text="Standing By...", foreground='blue')
        


        window.after(15, cmdMain)


def cmdAlertTelegramUser():
    global photoCount
    global isTelegramOnline

    if(isTelegramOnline):
        bot.sendMessage(1726351746,"Alert!!")
        bot.sendPhoto(1726351746, open('/home/pi/Desktop/ProjectCode/PiCameraGallery/pic' + str(photoCount) + '.jpg','rb'))


def cmdCheckDistance():
    global timer
    global lblCloseProximityDetectorStatus

    # set Trigger to HIGH
    GPIO.output(GPIO_TRIGGER, True)

    # set Trigger after 0.01ms to LOW
    time.sleep(0.00001)
    GPIO.output(GPIO_TRIGGER, False)

    StartTime = time.time()
    StopTime = time.time()

    # save StartTime
    while GPIO.input(GPIO_ECHO) == 0:
        StartTime = time.time()

    # save time of arrival
    while GPIO.input(GPIO_ECHO) == 1:
        StopTime = time.time()

    # time difference between start and arrival
    TimeElapsed = StopTime - StartTime
    # multiply with the sonic speed (34300 cm/s)
    # and divide by 2, because there and back
    distance = (TimeElapsed * 34300) / 2
    
    # if below threshold, take a photo and start detecting close range
    if int(distance) <= activationRange:
        lblCloseProximityDetectorStatus.config(text="ON", foreground='green')
        cmdTakePhotoWhenDetected()
        cmdProximityTimer()
        cmdCheckProximity()      
        
    else:
        lblMotionDetectorStatus.config(text=str(round(distance,2))+ " cm", foreground='red')
        lblCloseProximityDetectorStatus.config(text="Standing By...", foreground='blue')
        window.after(15, cmdMain)

def cmdProximityTimer():
    global proximityStartTime
    global proximityEndTime

    proximityStartTime = time.time()
    proximityEndTime = proximityStartTime + 20

    #print (round(proximityStartTime,2))
    #print (round(proximityEndTime,2))

def cmdSleepTimer():
    global sleepStartTime
    global sleepEndTime

    getSelection = str(dropSleepTimeClicked.get())
    selection = int(re.search(r'\d+', getSelection).group())

    sleepStartTime = time.time()
    sleepEndTime = sleepStartTime + selection
    

#REVISION AREA
def tgHandle(msg):
    global isUserTypingMsg
    global isTelegramOnline
    global pauseTime
    global isParameterBeingAdjusted
    global pauseTimeParameter
    global activationRange
    global sleepTimer

    chat_id = msg['chat']['id']
    command = msg['text']





    if isParameterBeingAdjusted:
        startingLetter = re.sub(r'[0-9]+', '', command)
        print(startingLetter)
        if startingLetter[0] == 'a':
            value = int(re.search("\d+", command)[0])
            print(value)
            dropActivationClicked.set(str(value) + " cm")
            isParameterBeingAdjusted = False
            activationRange = value
            bot.sendMessage(chat_id, "Activation distance successfully changed.")
            return
        elif startingLetter[0] == 'b':
            value = int(re.search("\d+", command)[0])
            print(value)
            dropSleepTimeClicked.set(str(value) + " secs")
            isParameterBeingAdjusted = False
            sleepTimer = value
            bot.sendMessage(chat_id, "Sleep timer successfully changed.")
            return
        elif startingLetter[0] == 'c':
            value = int(re.search("\d+", command)[0])
            print(value)
            dropPauseTimerClicked.set(str(value) + " secs")
            isParameterBeingAdjusted = False
            pauseTimeParameter = value
            bot.sendMessage(chat_id, "Pause timer successfully changed.")
            return
        else:
            bot.sendMessage(chat_id, "Incorrect Syntax.")
            isParameterBeingAdjusted = False


    if isUserTypingMsg:
        bot.sendMessage(chat_id, "Displaying Message")
        cmdSendFromTelegram(command)
        isUserTypingMsg = False


    print ('Got command: %s' % command)

    if command == 'start':
        isTelegramOnline = True
        bot.sendMessage(chat_id, "I am online :)")
        bot.sendMessage(chat_id, "Here is the list of commands.")
        bot.sendMessage(chat_id, "off: Turns off the telegram system.")
        bot.sendMessage(chat_id, "capture: Captures a photo and sends to user.")
        bot.sendMessage(chat_id, "alarm: Rings the alarm.")
        bot.sendMessage(chat_id, "send msg: Display short msg to LCD.")
        bot.sendMessage(chat_id, "pause: Pauses system.")
        bot.sendMessage(chat_id, "unplug: Ends system session.")
        bot.sendMessage(chat_id, "adjust parameter: Allows editing of parameters.")    

    if isTelegramOnline:
        if command == 'off':
            isTelegramOnline = False
            bot.sendMessage(chat_id, "Telegram system going offline...")
        elif command == 'capture':                
            bot.sendMessage(chat_id, "Taking Photo")
            cmdTakePhoto()
            bot.sendPhoto(1726351746, open('/home/pi/Desktop/ProjectCode/PiCameraGallery/pic' + str(photoCount) + '.jpg','rb'))
        elif command == 'send msg':
            isUserTypingMsg = True
            bot.sendMessage(chat_id, "Input Msg:")
        elif command == 'alarm':
            bot.sendMessage(chat_id, "Beep Beep...")
            cmdAlarm()
        elif command == 'pause':
            cmdPause()
            tmpPauseTime = pauseTime -time.time()
            bot.sendMessage(chat_id, "Pausing System for " + str(round(tmpPauseTime,2)) + " seconds")
        elif command == 'unplug':
            bot.sendMessage(chat_id, "Suspending system... Goodbye! ")
            window.after(15, cmdExit)
        elif command == 'adjust parameter':
            bot.sendMessage(chat_id, "Which parameter? Choose a letter and value. Choices: (a) Activation Distance, (b) Sleep Time, (c) Pause Time. Ex: A 10")
            isParameterBeingAdjusted = True

bot.message_loop(tgHandle)

#Loop
window.after(15, cmdMain)

# Run forever!
window.mainloop()

# Neatly release GPIO resources once window is closed
GPIO.cleanup()
 
