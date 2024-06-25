import time #load time library
import RPi.GPIO as GPIO #load GPIO library

led_pin = 23 #Pin definitions

GPIO.setwarnings(False) #Supress warnings
GPIO.setmode(GPIO.BCM) #Use "GPIO" pin numbering

GPIO.setup(23,GPIO.OUT) #Set LED pin as output


#Blink LED
while True:
        GPIO.output(led_pin, GPIO.HIGH) #Turn LED on
        time.sleep(1) #Delay for 1 second
        GPIO.output(led_pin, GPIO.LOW) #Turn LED of
        time.sleep(1) #Delay for 1 second
    
GPIO.cleanup() #reset the pin's statuses to their default states
