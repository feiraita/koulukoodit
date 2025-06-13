import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        System.out.print("Anna vuosi: ");
        int input = scan.nextInt();
        boolean leapyear = false;

        if (input < 1582) {
            System.out.printf("Vuosilukusyöte %d on virheellinen!", input);
            return;
        } else if ((input % 4 == 0 && input % 100 != 0) || (input % 400 == 0)) {
            leapyear = true;
        }

        if (leapyear) {
            System.out.printf("Vuosi %d on karkausvuosi.", input);
        } else {
            System.out.printf("Vuosi %d ei ole karkausvuosi.", input);
        }
    }
}