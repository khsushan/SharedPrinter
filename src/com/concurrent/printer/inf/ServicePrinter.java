package com.concurrent.printer.inf;

/** *********************************************************************
 * File:	  ServicePrinter.java (INTERFACE)	
 * Author:	  P. Howells	
 * Contents:  7SENG007W CWK  
 *            This provides the interface for the technicians  
 *		      to use & service the printer. 
 * Created:	  10/9/17
 * Modified:  1/2/18
 * Version:	  1.0	
 ************************************************************************ */

public interface ServicePrinter extends Printer
{

    // from Printer:
    //    public void printDocument( Document document ) ;

    // Printer constants 

    public final int Full_Paper_Tray  = 250 ;
    public final int Full_Toner_Level = 500 ;

    public final int Minimum_Toner_Level = 10 ;

    public final int SheetsPerPack = 50 ;

    public final int PagesPerTonerCartridge = 500 ;


    // Technician methods

    public void replaceTonerCartridge() ;

    public void refillPaper() ;
    
}

