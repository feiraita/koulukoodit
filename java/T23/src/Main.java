import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        while (true) {
            boolean leapyear = false;
            System.out.print("\nAnna vuosi, -1 lopettaa ajon: ");
            int input = scan.nextInt();
            if (input == -1) {
                System.out.println("Ohjelman ajo loppuu, näkemiin!");
                break;
            } else if (input < 1582) {
                System.out.printf("Vuosilukusyöte %d on virheellinen!", input);
                return;
            }

            if ((input % 4 == 0 && input % 100 != 0) || (input % 400 == 0)) {
                leapyear = true;
            }
            if (leapyear) {
                System.out.printf("Vuosi %d on karkausvuosi.", input);
            } else {
                System.out.printf("Vuosi %d ei ole karkausvuosi.", input);
            }
        }
    }
}