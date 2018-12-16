// Main Firmware for our OBD2 Device
// Used to obtain specific PID requests from a vehicle
// Created by Danny Campbell, Kale Thompson, Josh Vidmar


#include<vector>
#include<string>

CANChannel can(CAN_D1_D2);
//SYSTEM_MODE(SEMI_AUTOMATIC);


int led1 = D7;
int standby = D0;

bool rpmReceived;
bool speedReceived;
bool engineTempReceived;
bool fuelLevelReceived;
bool odometerReceived;
bool firstSent;
bool lastMessage;
int count;

void configureMessages();

void rpmMessage();
void speedMessage();
void engineTempMessage();
void fuelLevelMessage();
void odometerMessage();

void receiveData();

String decodedMessage;
String intermMessage;


char identifier[10];

CANMessage sendMessage;
CANMessage receiveMessage;

void setup() 
{
    firstSent = false;
    count = 0;
    
    Serial.begin(9600);
    pinMode(led1, OUTPUT);
    pinMode(standby, OUTPUT);
    digitalWrite(standby,LOW);
    can.begin(500000);
}


void loop() {
    
    while(!(Particle.connected()))
    {
        digitalWrite(led1, HIGH);
        delay(250);
        digitalWrite(led1, LOW);
        delay(250);
    }
    
    while(can.receive(receiveMessage))
    {
        // Reset the state for each message
        configureMessages();
        

        // Send each PID and wait for a response, then move onto the next PID
        Serial.println("RPM");
        rpmMessage();
        Serial.println("SPEED");
        speedMessage();
        Serial.println("TEMP");
        engineTempMessage();
        Serial.println("FUEL");
        lastMessage = true;
        fuelLevelMessage();
        
        Serial.println("Transformed Data");
        Serial.println(decodedMessage);
        Serial.println("");
        
        Particle.publish("OBD2_Data", decodedMessage);
        delay(1000);
        
        
    }

}

// PID Request Methods
void configureMessages()
{
    // Clear out data from last transmission
    decodedMessage = "";
    
    // Build up identifier coming in
    decodedMessage += "7e8";
    decodedMessage += "-";
    
    // Used to format messages correctly 
    lastMessage = false;
    
    // Used to control flow through the process of receiving each message
    rpmReceived = false;
    speedReceived = false;
    engineTempReceived = false;
    odometerReceived = false;
    fuelLevelReceived = false;
}

void rpmMessage()
{
    intermMessage = "";
    
    sendMessage.id = 0x7DF;
    sendMessage.len = 8;
    sendMessage.data[0] = 0x02;
    sendMessage.data[1] = 0x01;
    sendMessage.data[2] = 0x0C;
    
    
    
    while(rpmReceived == false)
    {
        while(can.receive(receiveMessage))
        {
            if(receiveMessage.id == 0x7E8 && receiveMessage.data[2] == 12)
            {
                rpmReceived = true;
                receiveData();
                break;
            }
            can.transmit(sendMessage);
        }
        
    }
}

void speedMessage()
{
    intermMessage = "";
    
    sendMessage.id = 0x7DF;
    sendMessage.len = 8;
    sendMessage.data[0] = 0x02;
    sendMessage.data[1] = 0x01;
    sendMessage.data[2] = 0x0D;
    
    while(speedReceived == false)
    {
        while(can.receive(receiveMessage))
        {
            if(receiveMessage.id == 0x7E8 && receiveMessage.data[2] == 13 )
            {
                speedReceived = true;
                receiveData();
                break;
            }
            can.transmit(sendMessage);
        }
        
    } 
}

void engineTempMessage()
{
    intermMessage = "";
    
    sendMessage.id = 0x7DF;
    sendMessage.len = 8;
    sendMessage.data[0] = 0x02;
    sendMessage.data[1] = 0x01;
    sendMessage.data[2] = 0x05;
    
    while(engineTempReceived == false)
    {
        while(can.receive(receiveMessage))
        {
            if(receiveMessage.id == 0x7E8 && receiveMessage.data[2] == 5 )
            {
                engineTempReceived = true;
                receiveData();
                break;
            }
            can.transmit(sendMessage);
        }
        
    } 
}

void odometerMessage()
{
    intermMessage = "";
    
    sendMessage.id = 0x7DF;
    sendMessage.len = 8;
    sendMessage.data[0] = 0x02;
    sendMessage.data[1] = 0x01;
    sendMessage.data[2] = 0xA6;
    
    Serial.println("ODOMETER");
    Serial.println("");
    
    while(odometerReceived == false)
    {
        while(can.receive(receiveMessage))
        {
            if(receiveMessage.id == 0x7E8 && receiveMessage.data[2] == 166 )
            {
                odometerReceived = true;
                receiveData();
                break;
            }
            can.transmit(sendMessage);
        }
        
    } 
}

void fuelLevelMessage()
{
    intermMessage = "";
    
    sendMessage.id = 0x7DF;
    sendMessage.len = 8;
    sendMessage.data[0] = 0x02;
    sendMessage.data[1] = 0x01;
    sendMessage.data[2] = 0x2F;
    
    while(fuelLevelReceived == false)
    {
        while(can.receive(receiveMessage))
        {
            if(receiveMessage.id == 0x7E8 && receiveMessage.data[2] == 47 )
            {
                fuelLevelReceived = true;
                receiveData();
                break;
            }
            can.transmit(sendMessage);
        }
        
    } 
}

void receiveData()
{
    // Building Final data output that will be pushed to the database
    itoa(receiveMessage.data[3], identifier, 16);
    decodedMessage += identifier;
    decodedMessage += "-";
    itoa(receiveMessage.data[4], identifier, 16);
    decodedMessage += identifier;
    if(!lastMessage)
    {
        decodedMessage += "-";    
    }
    
    // Builds interm message to be displayed to the console
    itoa(receiveMessage.id, identifier, 16);
    intermMessage += identifier;
    intermMessage += "-";
    intermMessage += receiveMessage.len;
    intermMessage += "-";
    
    for(int i = 0; i < receiveMessage.len; i++)
    {
        itoa(receiveMessage.data[i], identifier, 16);
        intermMessage += identifier;
        if(i != receiveMessage.len - 1)
        {
            intermMessage += "-";
        }
        
    }
    
    Serial.println(intermMessage);
    Serial.println("");
}




