import time #load time library
import RPi.GPIO as  GPIO #load  GPIO library

SegmentPinA = 1
SegmentPinF = 7
SegmentPinG = 8
SegmentPinB = 25
SegmentPinE = 2
SegmentPinD = 3
SegmentPinC = 4

GPIO.setwarnings(False) # Suppress warnings
GPIO.setmode(GPIO.BCM) # Use "Gpio" pin numbering
GPIO.setup(SegmentPinA, GPIO.OUT)
GPIO.setup(SegmentPinF, GPIO.OUT)
GPIO.setup(SegmentPinG, GPIO.OUT)
GPIO.setup(SegmentPinB, GPIO.OUT)
GPIO.setup(SegmentPinE, GPIO.OUT)
GPIO.setup(SegmentPinD, GPIO.OUT)
GPIO.setup(SegmentPinC, GPIO.OUT)

# Light up LED when Button is pressed
while True:
    
    GPIO.output(SegmentPinA, GPIO.HIGH)
    GPIO.output(SegmentPinF, GPIO.HIGH)
    GPIO.output(SegmentPinG, GPIO.HIGH)
    GPIO.output(SegmentPinB, GPIO.HIGH)
    GPIO.output(SegmentPinE, GPIO.HIGH)
    GPIO.output(SegmentPinD, GPIO.LOW)
    GPIO.output(SegmentPinC, GPIO.HIGH)
    time.sleep(2)
    GPIO.output(SegmentPinA, GPIO.LOW)
    GPIO.output(SegmentPinF, GPIO.LOW)
    GPIO.output(SegmentPinG, GPIO.HIGH)
    GPIO.output(SegmentPinB, GPIO.HIGH)
    GPIO.output(SegmentPinE, GPIO.HIGH)
    GPIO.output(SegmentPinD, GPIO.HIGH)
    GPIO.output(SegmentPinC, GPIO.HIGH)
    time.sleep(1)
    GPIO.output(SegmentPinA, GPIO.LOW)
    GPIO.output(SegmentPinF, GPIO.LOW)
    GPIO.output(SegmentPinG, GPIO.LOW)
    GPIO.output(SegmentPinB, GPIO.LOW)
    GPIO.output(SegmentPinE, GPIO.LOW)
    GPIO.output(SegmentPinD, GPIO.LOW)
    GPIO.output(SegmentPinC, GPIO.LOW)
    time.sleep(1)
    GPIO.output(SegmentPinA, GPIO.LOW)
    GPIO.output(SegmentPinF, GPIO.LOW)
    GPIO.output(SegmentPinG, GPIO.HIGH)
    GPIO.output(SegmentPinB, GPIO.HIGH)
    GPIO.output(SegmentPinE, GPIO.HIGH)
    GPIO.output(SegmentPinD, GPIO.HIGH)
    GPIO.output(SegmentPinC, GPIO.HIGH)
    time.sleep(2)
    GPIO.output(SegmentPinA, GPIO.LOW)
    GPIO.output(SegmentPinF, GPIO.HIGH)
    GPIO.output(SegmentPinG, GPIO.LOW)
    GPIO.output(SegmentPinB, GPIO.HIGH)
    GPIO.output(SegmentPinE, GPIO.HIGH)
    GPIO.output(SegmentPinD, GPIO.HIGH)
    GPIO.output(SegmentPinC, GPIO.HIGH)
    time.sleep(2)
    

GPIO.cleanup() #reset the pin's statuses to their default states