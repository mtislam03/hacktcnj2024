using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WordGenerator : MonoBehaviour
{
    private Dictionary<WordType, string[]> all_words = new Dictionary<WordType, string[]>();

    public enum WordType { 
        SIX_LETTER, ANIMALS, FOOD, MOVIES, SPORTS, COLORS, VEHICLES
    }

    // Start is called before the first frame update
    void Start()
    {
        all_words.Add(WordType.SIX_LETTER, six_letter_words);
        all_words.Add(WordType.ANIMALS, animals);
        all_words.Add(WordType.FOOD, food);
        all_words.Add(WordType.MOVIES, movies);
        all_words.Add(WordType.SPORTS, sports);
        all_words.Add(WordType.COLORS, colors);
        all_words.Add(WordType.VEHICLES, vehicles);
    }

    public void GetWord(WordType category)
    {
        //something
            
    }

    string[] six_letter_words = {
        "Abroad", "Casual", "Around", "Couple",
        "Accept", "Caught", "Arrive", "Course",
        "Access", "Centre", "Artist", "Covers",
        "Across", "Aspect", "Create",
        "Acting", "Chance", "Assess", "Credit",
        "Action", "Change", "Assist", "Crisis",
        "Active", "Charge", "Assume", "Custom",
        "Actual", "Choice", "Attack", "Damage",
        "Advice", "Choose", "Attend", "Danger",
        "Advise", "Chosen", "August", "Dealer",
        "Affect", "Church", "Author", "Debate",
        "Afford", "Circle", "Avenue", "Decade",
        "Afraid", "Client", "Backed", "Decide",
        "Agency", "Closed", "Barely", "Defeat",
        "Agenda", "Closer", "Battle", "Defend",
        "Almost", "Coffee", "Beauty", "Define",
        "Always", "Column", "Became", "Degree",
        "Amount", "Combat", "Become", "Demand",
        "Animal", "Coming", "Before", "Depend",
        "Annual", "Common", "Behalf", "Deputy",
        "Answer", "Comply", "Behind", "Desert",
        "Anyone", "Copper", "Belief", "Design",
        "Anyway", "Corner", "Belong", "Desire",
        "Appeal", "Costly", "Beaker", "Detail",
        "Appear", "County", "Better", "Detect",
        "Beyond", "Budget", "During", "Device",
        "Bishop", "Burden", "Easily", "Differ",
        "Border", "Bureau", "Eating", "Dinner",
        "Bottle", "Button", "Editor", "Direct",
        "Bottom", "Camera", "Effect", "Doctor",
        "Bought", "Cancer", "Effort", "Dollar",
        "Branch", "Cactus", "Eighth", "Domain",
        "Breath", "Carbon", "Either", "Double",
        "Bridge", "Career", "Eleven", "Driven",
        "Bright", "Castle", "Emerge", "Driver",
        "Easily", "Eating", "Editor", "Effect",
        "Effort", "Eighth", "Either", "Eleven",
        "Emerge", "Empire", "Employ", "Enable",
        "Ending", "Energy", "Engage", "Engine",
        "Enough", "Ensure", "Entire", "Entity",
        "Equity", "Escape", "Estate", "Ethnic",
        "Exceed", "Except", "Excess", "Expand",
        "Expect", "Expert", "Export", "Extend",
        "Fabric", "Facing", "Factor", "Failed",
        "Fairly", "Fallen", "Family", "Famous",
        "Father", "Fellow", "Female", "Figure",
        "Filing", "Finger", "Finish", "Fiscal",
        "Flight", "Flying", "Follow", "Forced",
        "Forest", "Forget", "Formal", "Format",
        "Former", "Foster", "Fought", "Fourth", 
        "French", "Friend", "Future", "Garden",
        "Gather", "Gender", "German", "Global",
        "Golden", "Ground", "Growth", "Guilty",
        "Gabble", "Gadget", "Gainly", "Gallop",
        "Gamble", "Gamely", "Gazing", "Geneva",
        "Gently", "Giggle", "Ginger", "Girdle",
        "Gladly", "Glazed", "Glitch", "Gloomy",
        "Glowed", "Gluten", "Goggle", "Gossip",
        "Graded", "Grains", "Grassy", "Grater",
        "Gravel", "Grease", "Greedy", "Groove",
        "Grudge", "Guided", "Guitar", "Gunner",
        "Gurgle", "Gabber", "Gables", "Gaffes",
        "Gaiety", "Gainer", "Gander", "Gangly",
        "Gawked", "Gelled", "Hacker", "Haggle",
        "Halter", "Handle", "Hanger", "Happen",
        "Harass", "Harbor", "Hardly", "Harmed",
        "Hazard", "Heated", "Heaven", "Herbal",
        "Hereby", "Heroes", "Hinder", "Hinged", 
        "Hissed", "Hoarse", "Homily", "Hooded", 
        "Hoofed", "Hookah", "Hornet", "Horrid", 
        "Horsed", "Hosted", "Howard", "Humble", 
        "Hunter", "Hurled", "Hurray", "Hurted", 
        "Hutter", "Hybrid", "Hyster", "Hacked", 
        "Hagged", "Hailed", "Hailer", "Halers", 
        "Haling", "Handed", "Headed", "Health", 
        "Height", "Hidden", "Holder", "Honest",  
        "Impact", "Import", "Income", "Indeed", 
        "Injury", "Inside", "Intend", "Intent", 
        "Invest", "Island", "Itself", "Igloos", 
        "Inning", "Island", "Impose", "Innate", 
        "Instep", "Irides", "Inward", "Istles", 
        "Indent", "Indium", "Iodize", "Infant", 
        "Influx", "Infamy", "Insult", "Injure", 
        "Invest", "Invite", "Indict", "Inland", 
        "Insane", "Ironic", "Iodine", "Irises", 
        "Ironed", "Irides", "Issued", "Innate",   
        "Jersey", "Junior", "Jagged", "Jangle", 
        "Jargon", "Jarvis", "Jersey", "Jigsaw", 
        "Jingle", "Jogged", "Joiner", "Joking", 
        "Jumble", "Jumped", "Junker", "Jungle", 
        "Junior", "Jurors", "Juries", "Killed",
        "Kettle", "Keypad", "Kimchi", "Kinder", 
        "Kitten", "Knight", "Knives", "Knocks", 
        "Knotty", "Labour", "Latest", "Latter", 
        "Launch", "Lawyer", "Leader", "League", 
        "Leaves", "Legacy", "Length", "Lesson", 
        "Letter", "Lights", "Likely", "Linked", 
        "Liquid", "Listen", "Little", "Living", 
        "Losing", "Luxury", "Mainly", "Making",
        "Manage", "Manner", "Manual", "Margin", 
        "Marine", "Marked", "Market", "Master", 
        "Matter", "Mature", "Medium", "Member", 
        "Memory", "Mental", "Merely", "Merger", 
        "Method", "Middle", "Miller", "Mining", 
        "Minute", "Mirror", "Mobile", "Modern", 
        "Modest", "Module", "Moment", "Morris", 
        "Mostly", "Mother", "Motion", "Moving", 
        "Murder", "Museum", "Mutual", "Myself", 
        "Monkey", "Narrow", "Nation", "Native", 
        "Nature", "Nearby", "Nearly", "Nights", 
        "Nobody", "Normal", "Notice", "Notion", 
        "Number", "Nailed", "Namers", "Naming", 
        "Napkin", "Nectar", "Needed", "Object",
        "Obtain", "Office", "Offset", "Online", 
        "Option", "Orange", "Origin", "Output", 
        "Oxford", "Obeyed", "Oblast", "Oblong", 
        "Obsess", "Obtuse", "Occult", "Octane", 
        "Octave", "Ocular", "Oddest", "Oddity", 
        "Offend", "Oiling", "Okayed", "Oldest", 
        "Oldies", "Olives", "Omegas", "Omelet", 
        "Onions", "Onside", "Onward", "Opaque", 
        "Openly", "Operas", "Opiate", "Oppose", 
        "Optics", "Optime", "Oracle", "Orchid", 
        "Orient", "Orphan", "Ounces", "Outfit", 
        "Outing", "Outlaw", "Outran", "Outdid", 
        "Packed", "Palace", "Parent", "Partly", 
        "Patent", "People", "Period", "Permit", 
        "Person", "Phrase", "Picked", "Planet", 
        "Player", "Please", "Plenty", "Pocket", 
        "Police", "Policy", "Prefer", "Pretty", 
        "Prince", "Prison", "Profit", "Proper", 
        "Proven", "Public", "Pursue", "Raised", 
        "Random", "Rarely", "Rather", "Rating", 
        "Reader", "Really", "Reason", "Recall", 
        "Recent", "Record", "Reduce", "Reform", 
        "Regard", "Regime", "Region", "Relate", 
        "Relief", "Remain", "Remote", "Remove", 
        "Repair", "Repeat", "Replay", "Report", 
        "Rescue", "Resort", "Result", "Retail", 
        "Retain", "Return", "Reveal", "Review", 
        "Reward", "Riding", "Rising", "Robust", 
        "Ruling", "Safety", "Salary", "Sample", 
        "Saving", "Saying", "Scheme", "School", 
        "Screen", "Search", "Season", "Second", 
        "Secret", "Sector", "Secure", "Seeing", 
        "Select", "Seller", "Senior", "Series", 
        "Server", "Settle", "Severe", "Signal", 
        "Signed", "Silent", "Silver", "Simple", 
        "Simply", "Single", "Sister", "Slight", 
        "Smooth", "Social", "Solely", "Sought", 
        "Source", "Speech", "Spirit", "Spoken", 
        "Spread", "Spring", "Square", "Stable", 
        "Status", "Steady", "Stolen", "Strain", 
        "Stream", "Street", "Stress", "Strict", 
        "Strike", "String", "Strong", "Struck", 
        "Studio", "Submit", "Sudden", "Suffer", 
        "Summer", "Summit", "Supply", "Surely", 
        "Survey", "Switch", "Symbol", "System", 
        "Talent", "Taking", "Taught", "Tenant", 
        "Target", "Tender", "Tennis", "Thanks", 
        "Theory", "Thirty", "Though", "Threat", 
        "Thrown", "Ticket", "Timely", "Timing", 
        "Tissue", "Toward", "Travel", "Treaty", 
        "Trying", "Twelve", "Twenty", "Uglier", 
        "Upcome", "Update", "Upheld", "Uplift", 
        "Upload", "Upmost", "Uproar", "Uproot", 
        "Urchin", "Urinal", "Urgent", "Utmost", 
        "Unique", "Unless", "Useful", "Unlike", 
        "United", "Unable", "Vacant", "Vacate", 
        "Vacuum", "Vainly", "Valley", "Valors", 
        "Valued", "Values", "Vamped", "Vandal", 
        "Vapors", "Varies", "Varied", "Veggie", 
        "Veiled", "Velour", "Verify", "Vessel", 
        "Vigors", "Vigour", "Vipers", "Victim", 
        "Visual", "Versus", "Vision", "Volume", 
        "Walker", "Wealth", "Weekly", "Weight", 
        "Window", "Winner", "Winter", "Within", 
        "Wonder", "Worker", "Writer", "Yellow", 
        "Yachts", "Yapper", "Yearly", "Yogurt"
    };     

    string[] animals = {
        "Dog", "Cat", "Fish", "Bird",
        "Elephant", "Lion", "Tiger",
        "Bear", "Deer", "Horse",
        "Rabbit", "Monkey", "Gorilla",
        "Giraffe", "Zebra", "Kangaroo",
        "Koala", "Panda", "Dolphin",
        "Whale", "Shark", "Octopus",
        "Crab", "Lobster", "Snake",
        "Crocodile", "Alligator",
        "Turtle", "Frog", "Toad",
        "Lizard", "Gecko", "Chameleon",
        "Owl", "Eagle", "Hawk",
        "Falcon", "Seagull", "Pelican",
        "Swan", "Duck", "Goose", "Penguin",
        "Ostrich", "Emu", "Peacock",
        "Flamingo", "Parrot", "Cockatoo",
        "Canary", "Finch", "Sparrow",
        "Robin", "Bluejay", "Woodpecker",
        "Hummingbird", "Butterfly", "Dragonfly",
        "Moth", "Beetle", "Ladybug",
        "Bee", "Ant", "Grasshopper",
        "Wasp", "Caterpillar", "Cricket",
        "Centipede", "Millipede", "Scorpion",
        "Spider", "Tarantula", "Wolf",
        "Fox", "Coyote", "Hyena",
        "Otter", "Beaver", "Squirrel",
        "Chipmunk", "Raccoon", "Skunk",
        "Badger", "Shrew", "Hedgehog",
        "Rat", "Mole", "Guinea pig",
        "Mouse", "Chinchilla", "Hamster",
        "Gerbil", "Ferret", "Rabbit",
        "Lemur", "Armadillo",
    };

    string[] food = {
        "Pizza", "Burger", "Pasta", "Salad", "Sandwich", "Sushi", "Taco", "Burrito", "Soup", "Steak",
        "Chicken", "Fish", "Shrimp", "Lobster", "Crab", "Oyster", "Mussel", "Clam", "Calamari", "Tempura",
        "Ramen", "Noodle", "Rice", "Curry", "Sausage", "Bacon", "Pancake", "Waffle", "French toast", "Egg",
        "Omelette", "Quiche", "Frittata", "Bagel", "Donut", "Croissant", "Muffin", "Toast", "Jam", "Peanut butter",
        "Jelly", "Honey", "Yogurt", "Cheese", "Milk", "Yogurt", "Ice cream", "Gelato", "Sorbet", "Popsicle",
        "Chocolate", "Cake", "Cupcake", "Cookie", "Brownie", "Pie", "Tart", "Crumble", "Cobbler", "Pudding",
        "Jello", "Custard", "Trifle", "Tiramisu", "Cheesecake", "Creme brulee", "Macaron", "Souffle", "Truffle",
        "Fondue", "Marshmallow", "Caramel", "Popcorn", "Pretzel", "Chips", "Cracker", "Nachos", "Dip", "Salsa",
        "Guacamole", "Hummus", "Pita", "Falafel", "Kebab", "Gyro", "Shawarma", "Falafel", "Dumpling", "Spring roll",
        "Samosa", "Empanada", "Pierogi", "Gyoza", "Dim sum", "Bao", "Taco", "Burrito", "Quesadilla", "Enchilada",
        "Tamale"
    };

    string[] movies = {
        "Titanic", "Avatar", "Inception", "Jurassic Park", "Star Wars", "Harry Potter", "The Lord of the Rings", "The Avengers", "The Godfather", "The Shawshank Redemption",
        "Forrest Gump", "The Matrix", "The Dark Knight", "Toy Story", "Finding Nemo", "The Lion King", "Frozen", "Beauty and the Beast", "Aladdin", "Cinderella",
        "The Little Mermaid", "Snow White", "Mulan", "Brave", "Moana", "Zootopia", "Shrek", "Despicable Me", "Minions", "The Hunger Games",
        "The Twilight Saga", "The Maze Runner", "Divergent", "The Fault in Our Stars", "The Notebook", "Twilight", "Divergent", "Hunger Games", "The Maze Runner", 
        "The Fault in Our Stars", "Fifty Shades of Grey", "The Notebook", "Me Before You", "The Great Gatsby", "The Hobbit", "The Lord of the Rings", "The Hunger Games",
        "The Fault in Our Stars", "The Maze Runner", "Twilight", "Harry Potter", "The Chronicles of Narnia", "Jurassic Park", "Jaws", "The Shining", "Psycho", "Alien",
        "The Terminator", "Rambo", "Rocky", "Predator", "Die Hard", "Indiana Jones", "The Matrix", "Mission: Impossible", "The Fast and the Furious", "James Bond", "Star Trek",
        "The Avengers", "X-Men", "Spider-Man", "Batman", "Superman", "Iron Man", "Thor", "Captain America", "Wonder Woman", "Black Panther", "The Incredible Hulk", "Ant-Man",
        "Guardians of the Galaxy", "Doctor Strange", "Deadpool", "Aquaman", "Suicide Squad", "Justice League", "Captain Marvel", "Fantastic Four", "Blade", "The Punisher", 
        "Ghost Rider", "Venom", "Daredevil", "Luke Cage", "Iron Fist", "Jessica Jones", "The Defenders", "The Falcon and the Winter Soldier"
    };

    string[] sports = {
        "Soccer", "Football", "Basketball", "Baseball", "Tennis", "Golf", "Rugby", "Cricket", "Volleyball", "Hockey",
        "Badminton", "Table Tennis", "Swimming", "Diving", "Water Polo", "Surfing", "Skateboarding", "Snowboarding", "Skiing",
        "Bobsleigh", "Luge", "Skeleton", "Gymnastics", "Track and Field", "Marathon", "Triathlon", "Cycling", "BMX", "Mountain Biking",
        "Horse Racing", "Polo", "Rodeo", "Bull Riding", "Wrestling", "Judo", "Karate", "Taekwondo", "Boxing", "Muay Thai", "Kickboxing",
        "Mixed Martial Arts", "Fencing", "Archery", "Shooting", "Biathlon", "Decathlon", "Pentathlon", "Heptathlon", "Rowing",
        "Canoeing", "Kayaking", "Sailing", "Windsurfing", "Kitesurfing", "Rafting", "Water Skiing", "Wakeboarding", "Fishing", "Spearfishing",
        "Fly Fishing", "Ice Fishing", "Hunting", "Trapping", "Hiking", "Mountaineering", "Rock Climbing", "Bouldering", "Caving", "Orienteering",
        "Geocaching", "Paragliding", "Hang Gliding", "Skydiving", "BASE Jumping", "Wingsuit Flying", "Parachuting", "Aerobatics", "Acrobatics",
        "Trampoline", "High Jump", "Long Jump", "Pole Vault", "Discus Throw", "Shot Put", "Javelin Throw", "Hammer Throw", "Archery", "Shooting",
        "Billiards", "Bowling", "Curling", "Golf", "Boxing", "Skiing", "Snowboarding", "Skating", "Swimming"
    };

    string[] colors = {
         "White", "Black", "Red", "Blue", "Green", "Yellow", "Purple", "Orange", "Pink", "Brown",
        "Gray", "Cyan", "Magenta", "Lime", "Teal", "Indigo", "Maroon", "Olive", "Navy", "Beige",
        "Turquoise", "Lavender", "Periwinkle", "Violet", "Mauve", "Crimson", "Azure", "Coral", "Gold", "Silver",
        "Bronze", "Cream", "Ivory", "Sapphire", "Ruby", "Emerald", "Topaz", "Amber", "Slate", "Charcoal",
        "Mint", "Peach", "Lemon", "Sky Blue", "Steel Blue", "Forest Green", "Chocolate", "Tangerine", "Salmon",
        "Plum", "Mustard", "Fuchsia", "Aquamarine", "Royal Blue", "Baby Blue", "Cerulean", "Cobalt",
        "Cotton Candy", "Bubblegum", "Pumpkin", "Lilac", "Burgundy", "Mahogany", "Jade", "Orchid", 
        "Poppy", "Rust", "Saffron", "Terra Cotta", "Vanilla", "Amethyst", "Chartreuse", "Cinnamon", "Dandelion", 
        "Midnight Blue", "Mint Green", "Pastel Pink", "Raspberry", "Rose", "Scarlet", "Seafoam"
    };

    string[] vehicles = {
        "Car", "Truck", "Motorcycle", "Bus", "Bicycle", "Train", "Boat", "Scooter", "Van", "Helicopter", "Yacht", "Plane", 
        "Skateboard", "Skates", "Submarine", "Jet ski", "Blimp", "Rocket", "Kayak", "Canoe", "Tank",
        "Golf cart"
    };


}


