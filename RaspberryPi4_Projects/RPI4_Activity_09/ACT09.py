from tkinter import *
import RPi.GPIO as GPIO

# Declare global variables
val = True

#Use GPIO pin numbering
GPIO.setmode(GPIO.BCM)

#Declare Pin
led_pin = 23

#Set LED pin as output
GPIO.setup(led_pin,GPIO.OUT)
GPIO.output(led_pin,GPIO.LOW)

#Button press
def btnpress():
    global val
    if val == True:
        GPIO.output(led_pin, GPIO.HIGH)
        val = False
    else:
        GPIO.output(led_pin, GPIO.LOW)
        val = True
        
#Create the main window and its specifications
window = Tk()
window.title('GUI Button Controlled LED')
window.geometry("500x200+750+250")

#Add widgets
btn = Button(window, text="Button", foreground='blue', height=2,
             width = 5, command=btnpress)
btn.place(x=200,y=75)

#Run forever
window.mainloop()

#Release GPIO resources
GPIO.cleanup()