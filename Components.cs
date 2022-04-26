using System;
using SFML.Window;
using SFML.Graphics;
using SFML.System;

namespace Components
{
    class normal_attr
    {
        float voltage_in = 0;
        float voltage_out = 0;
        float resistance = 0;
        float amps = 0;
    }
    class resistor: normal_attr
    {
        Texture Resistor = new Texture("Sprites/Resistor.png");
        
    }
    class capacitor: normal_attr
    {
        Texture Capacitor = new Texture("Sprites/Capacitor.png");
    }
    
    class cell: normal_attr
    {
        Texture Cell = new Texture("Sprites/Cell.png");
    }
    class diode: normal_attr
    {
        Texture Diode = new Texture("Sprites/Diode.png");
    }
    class Switch: normal_attr
    {
        Texture openSwitch = new Texture("Sprites/Switch_open.png");
        Texture closedSwitch = new Texture("Sprites/Switch_close.png");
    }
}