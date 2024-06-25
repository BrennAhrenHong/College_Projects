float val = 0;
const int soundPin = A0;
const int photosenPin = A1;

void setup() {
  // put your setup code here, to run once:
  pinMode(2,INPUT);
  
  pinMode(4,OUTPUT);
  pinMode(5,OUTPUT);
  pinMode(6,OUTPUT);
  pinMode(7,OUTPUT);
  pinMode(8,OUTPUT);
  
  pinMode(9,OUTPUT);
  pinMode(10,OUTPUT);
  pinMode(11,OUTPUT);
  pinMode(12,OUTPUT);
  pinMode(13,OUTPUT);
}

void loop() {
  int digitalVal = digitalRead(3);

  if(digitalVal == HIGH)
  {
    val = analogRead(photosenPin);
    PhotoSensor();
  }
  else
  {
    val = analogRead(soundPin);
    SoundSensor();
  }
    
}

void PhotoSensor()
{

  if(val >= 150)
    digitalWrite(13,HIGH);
  else
    digitalWrite(13,LOW);

  if(val >= 250)
    digitalWrite(12,HIGH);
  else
    digitalWrite(12,LOW);

  if(val >= 350)
    digitalWrite(11,HIGH);
  else
    digitalWrite(11,LOW);

  if(val >= 450)
    digitalWrite(10,HIGH);
  else
    digitalWrite(10,LOW);

  if(val >= 550)
    digitalWrite(9,HIGH);
  else
    digitalWrite(9,LOW);

  if(val >= 650)
    digitalWrite(8,HIGH);
  else
    digitalWrite(8,LOW);

  if(val >= 750)
    digitalWrite(7,HIGH);
  else
    digitalWrite(7,LOW);

  if(val >= 850)
    digitalWrite(6,HIGH);
  else
    digitalWrite(6,LOW);

  if(val >= 900)
    digitalWrite(5,HIGH);
  else
    digitalWrite(5,LOW);

  if(val >= 925)
    digitalWrite(4,HIGH);
  else
    digitalWrite(4,LOW);
}

void SoundSensor()  
{
  
  if(val >= 600)
    digitalWrite(13,HIGH);
  else
    digitalWrite(13,LOW);

  if(val >= 625)
    digitalWrite(12,HIGH);
  else
    digitalWrite(12,LOW);

  if(val >= 645)
    digitalWrite(11,HIGH);
  else
    digitalWrite(11,LOW);

  if(val >= 665)
    digitalWrite(10,HIGH);
  else
    digitalWrite(10,LOW);

  if(val >= 700)
    digitalWrite(9,HIGH);
  else
    digitalWrite(9,LOW);

  if(val >= 725)
    digitalWrite(8,HIGH);
  else
    digitalWrite(8,LOW);

  if(val >= 750)
    digitalWrite(7,HIGH);
  else
    digitalWrite(7,LOW);

  if(val >= 775)
    digitalWrite(6,HIGH);
  else
    digitalWrite(6,LOW);

  if(val >= 800)
    digitalWrite(5,HIGH);
  else
    digitalWrite(5,LOW);

  if(val >= 825)
    digitalWrite(4,HIGH);
  else
    digitalWrite(4,LOW);
}
