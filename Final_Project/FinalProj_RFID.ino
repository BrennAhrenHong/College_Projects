#include <SPI.h>
#include <RFID.h>

RFID rfid(10, 5);

int DataPinOne = 0;
int DataPinTwo = 0;

int WifiControlState_OutletA = LOW;
int WifiControlState_OutletB = LOW;

int OutletState_A = LOW;
int OutletState_B = LOW;

bool OutletA_Selected = true;
bool OutletB_Selected = false;

int buttonA_State = LOW;
int buttonB_State = LOW;

bool RFID_MODE = true;

const int OutletA_Pin = 3;
const int OutletB_Pin = 4;


unsigned char serNum[5];
unsigned char status;
unsigned char str[MAX_LEN];
unsigned char blockAddr;

String MasterID = "ecb40e49";  // REPLACE this Tag ID with your Tag ID!!!
String OutletA_ID = "335f7a1a";
String OutletB_ID = "22910834";
String ChangeModeID = "b01a8032";
String Read_ID = "";

unsigned char sectorKeyA[16][16] = {
  {  0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF  } ,
  {  0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF  } ,
  {  0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF  } ,
  {  0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF  } ,
  {  0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF  } ,
  {  0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF  } ,
  {  0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF  } ,
  {  0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF  } ,
  {  0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF  } ,
  {  0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF  } ,
  {  0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF  } ,
  {  0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF  } ,
  {  0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF  } ,
  {  0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF  } ,
  {  0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF  } ,
  {  0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF  } ,
};

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  SPI.begin();
  rfid.init();


  pinMode(6,INPUT);
  pinMode(7,INPUT);

  pinMode(A4, INPUT);
  pinMode(A5, INPUT);
  
  pinMode(OutletA_Pin,OUTPUT);
  pinMode(OutletB_Pin,OUTPUT);

}

void loop() {
  // put your main code here, to run repeatedly:
  ReadButton();
  findCard();
  
   
  if(!RFID_MODE)
  {
    UpdateWifiPinState();    
  }

  UpdateDataPinState();
  
 
}

//Read the selector button inputs
void ReadButton()
{
  buttonA_State = digitalRead(A5);
  buttonB_State = digitalRead(A4);

  if(buttonA_State == HIGH)
  {
    OutletA_Selected = true;
    OutletB_Selected = false;
    Serial.println("Outlet A is selected");
  }
  else if(buttonB_State == HIGH)
  {
    OutletA_Selected = false;
    OutletB_Selected = true;
    Serial.println("Outlet B is selected");
  }
}
  
//Find if card is present
void findCard()
{
  rfid.findCard(PICC_REQIDL, str);

  if (rfid.anticoll(str) == MI_OK) {
    Read_ID = "";
    char id[8];
    Serial.print("The card's number is  : ");

    for (int i = 0; i < 4; i++) {
      Serial.print(0x0F & (str[i] >> 4), HEX);
      Serial.print(0x0F & str[i], HEX);
      Read_ID += String(0x0F & (str[i] >> 4), HEX);
      Read_ID += String(0x0F & (str[i]), HEX);

    }
//    id[8] = Read_ID;
//    char chr;
//
//    int i = 0;
//    while(id[i]){
//      chr = Read_ID[i];
//      toupper(chr);
//      i++;
//    }
    
    Serial.println("");
    Serial.println(Read_ID);
    memcpy(rfid.serNum, str, 5);
  }

  rfid.selectTag(rfid.serNum);

  readCard(4);

  rfid.halt();
}

//Process RFID card. Will only process it if RFID mode is on.
void readCard(int blockAddr) {

  if ( rfid.auth(PICC_AUTHENT1A, blockAddr, sectorKeyA[blockAddr / 4], rfid.serNum) == MI_OK)
  {
    if(RFID_MODE)
    RFID_StateChange();

    if(Read_ID == ChangeModeID)
    {
      if(RFID_MODE)
      {
        RFID_MODE = false;
        Serial.println("RFID OFF");
      }        
        else
        {
          RFID_MODE = true;
          Serial.println("RFID ON");
        }
        
    }
      
  }
}

//Check for WIFI input only in WIFI mode
void UpdateWifiPinState()
{
  WifiControlState_OutletA = digitalRead(6);
  WifiControlState_OutletB = digitalRead(7);  
  
  if(WifiControlState_OutletA == LOW)
  {
    OutletState_A = LOW;
    //Serial.println("Turning off outlet A");
  }
  else
  {
    OutletState_A = HIGH;
    //Serial.println("Turning on outlet A");
  }

  if(WifiControlState_OutletB == LOW)
  {
    OutletState_B = HIGH;
    //Serial.println("Turning off outlet B");
  }
  else
  {
    OutletState_B = LOW;
    //Serial.println("Turning on outlet B");
  }
}

//Called when altering states via RFID
void RFID_StateChange(){
//Turn on/off both outlets
//ADD condition if which outlet is selected


    if(Read_ID == OutletA_ID  && OutletA_Selected || Read_ID == MasterID && OutletA_Selected)
    {
      Serial.println(" Access Granted!");
      if(OutletState_A == HIGH)
      {
        OutletState_A = LOW;
        Serial.println("Turning off outlet A");
      }
      else
      {
        OutletState_A = HIGH;       
        Serial.println("Turning on outlet A");
      }
    }
    //Turn on/off OutletB. Considering OutletB as active LOW
    else if(Read_ID == OutletB_ID && OutletB_Selected || Read_ID == MasterID && OutletB_Selected)
    {
      Serial.println(" Access Granted!");
      if(OutletState_B == LOW)
      {
        OutletState_B = HIGH;
        Serial.println("Turning off outlet B");
      }
      else
      {
        OutletState_B = LOW;
        Serial.println("Turning on outlet B");
      }
    }
    else
    {
      Serial.println(" Access Denied!");
    }

    delay(650);
}

//Called when an outlet's state is altered and is always called last.
void UpdateDataPinState()
{
  if(OutletState_A == HIGH)
  {
    digitalWrite(OutletA_Pin, HIGH);
  }
  else
  {
    digitalWrite(OutletA_Pin, LOW);
  }

  if(OutletState_B == HIGH)
  {
    digitalWrite(OutletB_Pin, LOW);
  }
  else
  {
    digitalWrite(OutletB_Pin, HIGH);
  }
}
