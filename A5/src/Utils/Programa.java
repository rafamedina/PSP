package Utils;

import java.io.File;
import java.io.IOException;
import java.util.Scanner;

public class Programa {
    String url;
    int num;
    public Programa(String url) {
        this.url =url;
    }

    public void Calcular() {
        File archivo;
        Scanner sc;
        try {
            archivo = new File(this.url);
            sc = new Scanner(archivo);
            this.num = Integer.parseInt(sc.nextLine());
        } catch (IOException e) {
            System.out.println(e.getMessage());
        }
        try{
            System.out.println("Tabla del: "+this.num);
            for(int i=1; i<=10 ; i++){
                System.out.println(this.num+" * "+i +" = " + this.num*i);
            }
        } catch (Exception e){
            System.out.println(e.getMessage());
        }
    }
}
