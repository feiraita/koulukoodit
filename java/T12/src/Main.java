import java.util.Scanner;

public class Main {
    public static void main(String[] args){
        Scanner scan = new Scanner(System.in);

        System.out.print("Give time length in seconds, has to be between 0-86399: ");
        int input = scan.nextInt();

        int sec = input % 60;
        int hour = input / 60;
        int min = hour % 60;
        hour = hour / 60;

        System.out.print(input +" seconds is " + hour + " hours, " + min + " minutes and " + sec + " seconds.");
    }
}
