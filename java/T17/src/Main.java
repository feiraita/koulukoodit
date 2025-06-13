import java.util.ArrayList;
import java.util.List;

public class Main {
    public static void main(String[] args) {
        List<String> numbers = new ArrayList<>();
        while (numbers.size() < 3) {
            int randomNum = (int)(Math.random() * 8);
            numbers.add(String.valueOf(randomNum));
        }
        String phonenumber = String.join("", numbers) + "-";

        phonenumber += (int)(Math.random() * (655 - 100 + 1)) + 100;

        numbers.clear();
        while (numbers.size() < 4) {
            int randomNum = (int)(Math.random() * 8);
            numbers.add(String.valueOf(randomNum));
        }
        phonenumber += "-" + String.join("", numbers);

        System.out.printf("Here is a random phone number: %s", phonenumber);
    }
}