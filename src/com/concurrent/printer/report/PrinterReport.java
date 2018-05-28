package com.concurrent.printer.report;

import java.util.ArrayList;
import java.util.List;

public class PrinterReport {

    private List<String> logs;
    private String printerName;

    public  PrinterReport(String printerName){
        logs = new ArrayList<String>();
        this.printerName = printerName;
    }

    public  void addLog(String log){
        logs.add(log);
    }

    public  void printReport(){
        System.out.println("------------------ Logs of "+this.printerName+"----------------------");
        for (String log: logs) {
            System.out.println(log);
        }
        System.out.println("----------------------------------------------------------------------");

    }
}
