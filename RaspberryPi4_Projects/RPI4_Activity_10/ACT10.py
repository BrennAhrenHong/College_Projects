#Import library
from tkinter import *
import RPi.GPIO as GPIO

#Use GPIO pin numbering
GPIO.setmode(GPIO.BCM)

#Pin Definitions
btn_pin = 16

#Set Led pin as an input
GPIO.setup(btn_pin, GPIO.IN)

# Checks if button is pressed or not
def btnpress():
    global btn_pin
    global lbl
    if not GPIO.input(btn_pin):
        lbl.config(text="BUTTON UNPRESSED", foreground='blue')
    else:
        lbl.config(text="BUTTON PRESSED", foreground ='red')
    window.after(10,btnpress)
    
# Create the main window and its specifications
window=Tk()
window.title('GUI Monitor')
window.geometry("500x200+750+250")

#Add widgets
lbl = Label(window, font=('Arial', 24))
lbl.place(x=100, y=50)

#btnpress function is called periodically
window.after(10,btnpress)

#Run forever!
window.mainloop()

#Neatly release GPIO resources once window is closed
GPIO.cleanup()