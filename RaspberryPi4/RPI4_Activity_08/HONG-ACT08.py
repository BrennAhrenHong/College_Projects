import I2C_LCD_driver 
import time
import RPi.GPIO as GPIO
from random import randrange

rowPins = [14, 15, 18, 23]
columnPins = [24, 25, 8, 7]

MysteryNumber = randrange(1,16)
Input = ""
counter = 0

GPIO.setwarnings(False) # supress warnings
GPIO.setmode(GPIO.BCM)  # USE GPIO pin numbering

#initialize components
GPIO.setup(columnPins[0], GPIO.OUT)
GPIO.setup(columnPins[1], GPIO.OUT)
GPIO.setup(columnPins[2], GPIO.OUT)
GPIO.setup(columnPins[3], GPIO.OUT)

GPIO.setup(rowPins[0], GPIO.OUT)
GPIO.setup(rowPins[1], GPIO.OUT)
GPIO.setup(rowPins[2], GPIO.OUT)
GPIO.setup(rowPins[3], GPIO.OUT)


lcd = I2C_LCD_driver.lcd()

#Read the input button
def readLine(line, characters):
    global Input
    
    GPIO.output(line, GPIO.HIGH)
    if(GPIO.input(columnPins[0]) == 1):
        Input = characters[0]
    if(GPIO.input(columnPins[1]) == 1):
        Input = characters[1]
    if(GPIO.input(columnPins[2]) == 1):
        Input = characters[2]
    if(GPIO.input(columnPins[3]) == 1):
        Input = characters[3]
    GPIO.output(line, GPIO.LOW)
    
def NumberComparator():
    global Input
    
    if int(MysteryNumber) > int(Input):
        return "HIGHER"
    elif int(Input) == int(MysteryNumber):
        return "YOU GOT IT :)"
    else:
        return "LOWER"
		
def CheckInput():
    global Input
    
    global MysteryNumber
    
    global counter
    
    if not Input == "" :
        
        lcd.lcd_clear()
        
        if int(Input) == int(MysteryNumber): #Prompt Correct answer
            lcd.lcd_display_string(NumberComparator(),1,0)
            lcd.lcd_display_string(Input + " WAS CORRECT!",2,0)
            counter = 0
            MysteryNumber = randrange(1,16)
            time.sleep(1.5)
            
        else: #Prompt incorrect number
            lcd.lcd_display_string(NumberComparator(),1,0)
            lcd.lcd_display_string(Input + " Wrong Number.",2,0)
            
            counter += 1
            
        if counter > 5 :
            time.sleep(0.5)
            lcd.lcd_clear()
            lcd.lcd_display_string("GAME OVER :(",1,0)
            lcd.lcd_display_string("Answer = " + str(MysteryNumber),2,1)
            counter = 0
            MysteryNumber = randrange(1,16)
            time.sleep(1.5)
        Input = ""
            
        time.sleep(0.5)
        lcd.lcd_clear()
    
try: 
    while True:
        lcd.lcd_display_string("Guess the number!",1,0)
        
        readLine(rowPins[0], ["1","2","3","4"])
        readLine(rowPins[1], ["5","6","7","8"])
        readLine(rowPins[2], ["9","10","11","12"])
        readLine(rowPins[3], ["13","14","15","16"])
        time.sleep(0.1)
        
        CheckInput()
        
except KeyboardInterrupt:
    print("\nEnd of Program")