package com.concurrent.printer.imp;

import com.concurrent.document.Document;
import com.concurrent.printer.inf.Printer;
import com.concurrent.printer.inf.ServicePrinter;
import com.concurrent.printer.report.PrinterReport;

public class LaserPrinter implements Printer,ServicePrinter {

    private int currentTonerLevel;
    private  int currentPageCount;
    private  int documentPrinted;
    private  String printerName;
    private  int maximumPageCount;
    private volatile PrinterReport printerReport;

    public LaserPrinter(int currentTonerLevel, int currentPageCount, String printerName, int maximumPageCount){
        this.printerName = printerName;
        this.currentPageCount = currentPageCount;
        this.currentTonerLevel = currentTonerLevel;
        this.maximumPageCount = maximumPageCount;
        printerReport = new PrinterReport(this.printerName);
        printerReport.addLog("Initial state of printer is : "+this.toString());
    }

    @Override
    public synchronized void replaceTonerCartridge() {
        if (currentTonerLevel == 0){
            currentTonerLevel +=  Full_Toner_Level;
            printerReport.addLog(Thread.currentThread().
                    getName() + " successfully replaces the Toner cartridge and printer status is :" + this.toString());
        }else {
            printerReport.addLog(Thread.currentThread().
                    getName() + " failed to replaces the Toner cartridge and printer status is :" + this.toString());
        }
        notifyAll();

    }

    @Override
    public synchronized void refillPaper() {
        if (currentPageCount+ 50 <= Full_Paper_Tray){
            this.currentPageCount += 50;
            printerReport.addLog(Thread.currentThread().
                    getName() + " successfully refills the papers and printer status is :" + this.toString());
        }else {
            printerReport.addLog(Thread.currentThread().
                    getName() + " failed to refills the papers and printer status is :" + this.toString());
        }
        notifyAll();
    }

    @Override
    public synchronized void printDocument(Document document) {
       while (currentPageCount == 0
               || currentTonerLevel == 0
               || currentTonerLevel < document.getNumberOfPages()
               || currentPageCount < document.getNumberOfPages()){
           try {
               wait();
           } catch (InterruptedException e) {
               e.printStackTrace();
           }
       }

       this.currentPageCount -=  document.getNumberOfPages();
       this.currentTonerLevel -= document.getNumberOfPages();
       this.documentPrinted  += document.getNumberOfPages();
       printerReport.addLog(Thread.currentThread().
                getName() + " successfully print the "+document.getNumberOfPages()+" pages and printer state is :" + this.toString());
       notifyAll();
    }

    @Override
    public synchronized String toString() {
        return "LaserPrinter[ " +
                "Printer Name=" + printerName +
                ", Current Page Count=" + currentPageCount +
                ", Document Printed=" + documentPrinted +
                ", Current Toner Level='" + currentTonerLevel + '\'' +
                ']';
    }

    public synchronized  void  printReport(){
        this.printerReport.printReport();
    }
}
