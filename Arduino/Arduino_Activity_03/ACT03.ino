/*
  Button

  Turns on and off a light emitting diode(LED) connected to digital pin 13,
  when pressing a pushbutton attached to pin 2.

  The circuit:
  - LED attached from pin 13 to ground through 220 ohm resistor
  - pushbutton attached to pin 2 from +5V
  - 10K resistor attached to pin 2 from ground

  - Note: on most Arduinos there is already an LED on the board
    attached to pin 13.

  created 2005
  by DojoDave <http://www.0j0.org>
  modified 30 Aug 2011
  by Tom Igoe

  This example code is in the public domain.

  https://www.arduino.cc/en/Tutorial/BuiltInExamples/Button
*/

// constants won't change. They're used here to set pin numbers:
const int buttonPinTwo = 2;     // the number of the pushbutton pin
const int buttonPinThree = 3;
const int buttonPinFour = 4;
const int buttonPinFive = 5;
const int ledPinGreenOne =  13;      // the number of the LED pin
const int myPins[] = {13,12,11,10,9,8,7,6};

// variables will change:
int buttonPower = 0;
int buttonState = 0;         // variable for reading the pushbutton status
int buttonStateTwo = 0; 
int x = 0;
int lastButtonState = 0;
void setup() {
  // initialize the LED pin as an output:
  pinMode(13, OUTPUT);
    // initialize the LED pin as an output:
  pinMode(12, OUTPUT);
      // initialize the LED pin as an output:
  pinMode(11, OUTPUT);
      // initialize the LED pin as an output:
  pinMode(10, OUTPUT);
      // initialize the LED pin as an output:
  pinMode(9, OUTPUT);
      // initialize the LED pin as an output:
  pinMode(8, OUTPUT);
      // initialize the LED pin as an output:
  pinMode(7, OUTPUT);
      // initialize the LED pin as an output:
  pinMode(6, OUTPUT);
  // initialize the pushbutton pin as an input:
  pinMode(buttonPinOne, INPUT);
    // initialize the pushbutton pin as an input:
  pinMode(buttonPinTwo, INPUT);
    // initialize the pushbutton pin as an input:
  pinMode(buttonPinThree, INPUT);
    // initialize the pushbutton pin as an input:
  pinMode(buttonPinFour, INPUT);

  
}

void loop() {
  // read the state of the pushbutton value:
  buttonPower = digitalRead(buttonPinOne);
  while()
  {
    if(buttonState != lastButtonState)
    {
    // check if the pushbutton is pressed. If it is, the buttonState is HIGH:
      if (buttonState == HIGH) {
    // turn LED on:
      digitalWrite(myPins[x], HIGH);
    x++;
        } else {
    // turn LED off:
          digitalWrite(myPins[x], LOW);
               }
      delay(1000);
    }
    lastButtonState = buttonState;

    if(x == 4)
    {
      digitalWrite(6,HIGH);
    }
  }

}
