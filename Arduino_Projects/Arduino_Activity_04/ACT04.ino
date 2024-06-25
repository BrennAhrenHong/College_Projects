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
int buttonOneState = 0;         // variable for reading the pushbutton status
int buttonTwoState = 0;
int buttonThreeState = 0;
int buttonFourState = 0;
int x = 0;
int lastButtonState = 0;
int buttonOnePattern = 0;
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
      
  pinMode(buttonPinTwo, INPUT);
      // initialize the pushbutton pin as an input:
  pinMode(buttonPinThree, INPUT);
      // initialize the pushbutton pin as an input:
  pinMode(buttonPinFour, INPUT);
      // initialize the pushbutton pin as an input:
  pinMode(buttonPinFive, INPUT);
}

void loop() {
  // read the state of the pushbutton value:
  buttonOneState = digitalRead(buttonPinTwo);
  buttonTwoState = digitalRead(buttonPinThree);
  buttonThreeState = digitalRead(buttonPinFour);
  buttonFourState = digitalRead(buttonPinFive);


//    if (buttonOneState == HIGH) {
//    // turn LED on:
//    digitalWrite(13, HIGH);           
//  } else {
//    // turn LED off:
//    digitalWrite(13, LOW);
//  }    

  // check if the pushbutton i


switch(buttonOneState)
{
  case HIGH:
  {
    int x = 7;
    while(x > -1)
    {
      digitalWrite(myPins[x], HIGH);
      x--;
    }
    if(buttonOnePattern == 1)
    {
      buttonOnePattern = 0;
    }
    else buttonOnePattern = 1;
    delay(250);
    break;
  }

  case LOW:
  {
    if(buttonOnePattern == 0)
    {
       int x = 7;
       while(x > -1)
       {
        digitalWrite(myPins[x], LOW);
        x--;
       }
    }

    break;
  }
  default:
  break;
}

switch(buttonTwoState)
{
  case HIGH:
  {
    int x = 7;
    while(x > -1)
    {
     digitalWrite(myPins[x], HIGH);
     delay(150);
     digitalWrite(myPins[x], LOW);
     delay(150);
     x--;
    }
  }
  default:
  break;
}

switch(buttonThreeState)
{
  case HIGH:
  {
    int x = 7;
    int y = 0;
    while(x > -1)
    {
      if(x == 4)
      {
        y++;
        x--;
      }
     digitalWrite(myPins[x], HIGH);
     digitalWrite(myPins[y], HIGH);
     delay(150);
     digitalWrite(myPins[x], LOW);
     digitalWrite(myPins[y], LOW);
     delay(150);
     y++;
     x--;
    }
  }

  default:
  break;
}

switch(buttonFourState)
{
  case HIGH:
  {
    int x = 7;
    int y = 6;
    int timeDelay = 250;
    int counter = 5;
    while(counter != 0)
    {
      if(x == 0)
      {
        x=7;
        y=6;
        timeDelay = timeDelay - 50;
      }
      
     digitalWrite(myPins[x], HIGH);
     digitalWrite(myPins[y], HIGH);
     delay(timeDelay);
     digitalWrite(myPins[x], LOW);
     digitalWrite(myPins[y], LOW);
     delay(timeDelay);
          
     y--;
     x--;
     if(x == 0)
     {
      counter--;
     }
    }
  }
  default:
  break;
}                                                                                                                                                                                   
  
}
