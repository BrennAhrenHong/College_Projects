import time #load time library
import RPi.GPIO as  GPIO #load  GPIO library

led_pin = 23 # Pin definitions
btn_pin = 16 # Pin definitions

GPIO.setwarnings(False) # Suppress warnings
GPIO.setmode(GPIO.BCM) # Use "Gpio" pin numbering
GPIO.setup(led_pin, GPIO.OUT) # Set LED pin as output
GPIO.setup(btn_pin, GPIO.IN) # Set Button pin as input

# Light up LED when Button is pressed
while True:
    if GPIO.input(btn_pin):
        GPIO.output(led_pin, GPIO.LOW)
    else:
        GPIO.output(led_pin, GPIO.HIGH)

GPIO.cleanup() #reset the pin's statuses to their default states