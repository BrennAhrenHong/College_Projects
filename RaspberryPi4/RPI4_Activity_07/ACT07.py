import I2C_LCD_driver #load I2C_LCD library
import time #load time library
import RPi.GPIO as GPIO #load GPIO library

mylcd = I2C_LCD_driver.lcd() #initialize I2C-LCD functions
btn1 = 4
btn2 = 17
btn3 = 27
btn4 = 22

GPIO.setwarnings(False) # Suppress warnings
GPIO.setmode(GPIO.BCM) # Use "Gpio" pin numbering
GPIO.setup(btn1, GPIO.IN)
GPIO.setup(btn2, GPIO.IN)
GPIO.setup(btn3, GPIO.IN)
GPIO.setup(btn4, GPIO.IN)

while True:
        #display message on LCD in rows,columns
        time.sleep(1)
        if GPIO.input(btn1):
            mylcd.lcd_display_string("ALPHA",1,1)
            
        if GPIO.input(btn2):
            mylcd.lcd_display_string("BRAVO",1,10)
            
        if GPIO.input(btn3):
            mylcd.lcd_display_string("CHARLIE",2,1)
            
        if GPIO.input(btn4):
            mylcd.lcd_display_string("DELTA",2,10)
            
        time.sleep(1) #1 second delay
        mylcd.lcd_clear() #clears LCD screen