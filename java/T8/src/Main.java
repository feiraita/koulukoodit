public class Main {
    public static void main(String[] args) {
        int savings = 1500;
        double interest = 0.025; // korkoprosentti 2,5%

        double after = savings + (savings * interest);

        System.out.println("Pääoma: " + savings );
        System.out.println("Korkoprosentti: " + interest);
        System.out.println("Pääoma vuoden jälkeen: " + after);
    }
}