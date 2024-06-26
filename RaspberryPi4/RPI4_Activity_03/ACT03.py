import time #load time library
import RPi.GPIO as  GPIO #load  GPIO library

led_pin1 = 2 # Pin definitions
led_pin2 = 3
led_pin3 = 4
led_pin4 = 17
led_pin5 = 27

btn_pin1 = 1 # Pin definitions
btn_pin2 = 7
btn_pin3 = 8

GPIO.setwarnings(False) # Suppress warnings
GPIO.setmode(GPIO.BCM) # Use "Gpio" pin numbering

GPIO.setup(led_pin1, GPIO.OUT) # Set LED pin as output
GPIO.setup(led_pin2, GPIO.OUT) # Set LED pin as output
GPIO.setup(led_pin3, GPIO.OUT) # Set LED pin as output
GPIO.setup(led_pin4, GPIO.OUT) # Set LED pin as output
GPIO.setup(led_pin5, GPIO.OUT) # Set LED pin as output

GPIO.setup(btn_pin1, GPIO.IN) # Set Button pin as input
GPIO.setup(btn_pin2, GPIO.IN) # Set Button pin as input
GPIO.setup(btn_pin3, GPIO.IN) # Set Button pin as input

# Light up LED when Button is pressed
while True:

    if GPIO.input(btn_pin1):
        GPIO.output(led_pin1, GPIO.HIGH)
        time.sleep(1)
        GPIO.output(led_pin2, GPIO.HIGH)
        time.sleep(1)
        GPIO.output(led_pin3, GPIO.HIGH)
        time.sleep(1)
        GPIO.output(led_pin4, GPIO.HIGH)
        time.sleep(1)
        GPIO.output(led_pin5, GPIO.HIGH)
        time.sleep(1)
        GPIO.output(led_pin1, GPIO.LOW)
        time.sleep(1)
        GPIO.output(led_pin2, GPIO.LOW)
        time.sleep(1)
        GPIO.output(led_pin3, GPIO.LOW)
        time.sleep(1)
        GPIO.output(led_pin4, GPIO.LOW)
        time.sleep(1)
        GPIO.output(led_pin5, GPIO.LOW)
        time.sleep(1)
    
    if GPIO.input(btn_pin2):
        GPIO.output(led_pin1, GPIO.HIGH)
        time.sleep(1)
        GPIO.output(led_pin1, GPIO.LOW)
        GPIO.output(led_pin2, GPIO.HIGH)
        time.sleep(1)
        GPIO.output(led_pin2, GPIO.LOW)
        GPIO.output(led_pin3, GPIO.HIGH)
        time.sleep(1)
        GPIO.output(led_pin3, GPIO.LOW)
        GPIO.output(led_pin4, GPIO.HIGH)
        time.sleep(1)
        GPIO.output(led_pin4, GPIO.LOW)
        GPIO.output(led_pin5, GPIO.HIGH)
        time.sleep(1)
        GPIO.output(led_pin5, GPIO.LOW)
        
       
    if GPIO.input(btn_pin3):
        x = 3
        
        while(x != 0):
            GPIO.output(led_pin1, GPIO.HIGH)
            GPIO.output(led_pin3, GPIO.HIGH)
            GPIO.output(led_pin5, GPIO.HIGH)
            GPIO.output(led_pin2, GPIO.LOW)
            GPIO.output(led_pin4, GPIO.LOW)
            time.sleep(1)
            GPIO.output(led_pin1, GPIO.LOW)
            GPIO.output(led_pin3, GPIO.LOW)
            GPIO.output(led_pin5, GPIO.LOW)
            GPIO.output(led_pin2, GPIO.HIGH)
            GPIO.output(led_pin4, GPIO.HIGH)
            time.sleep(1)
            x = x - 1
            
    GPIO.output(led_pin1, GPIO.LOW)
    GPIO.output(led_pin2, GPIO.LOW)
    GPIO.output(led_pin3, GPIO.LOW)
    GPIO.output(led_pin4, GPIO.LOW)
    GPIO.output(led_pin5, GPIO.LOW)

GPIO.cleanup() #reset the pin's statuses to their default states
