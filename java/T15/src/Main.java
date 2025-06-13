import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        System.out.print("Give me your first name: ");
        String firstName = scan.next().toLowerCase();
        char uFirst = firstName.charAt(0);

        System.out.print("Give me your last name: ");
        String lastName = scan.next().toLowerCase();

        String uLast;
        if (lastName.length() < 5) {
            uLast = lastName;
        } else {
            uLast = lastName.substring(0, 5);
        }

        int randomNumber = 10 + (int)(Math.random() * 90);

        String username = uFirst + uLast + randomNumber;
        System.out.printf("Your username is %s", username);

    }
}