using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Game : System.Web.UI.Page
{
    #region Word List
    private string[] words = { "Lively", "frog", "drunk", "illustrious", "street", "periodic",
        "flag", "dirt", "homeless", "trouble", "examine", "substance", "jaded", "milky", "high-pitched",
        "teeth", "three", "business", "hole", "disgusting", "wood", "settle", "cow", "abounding", "attractive",
        "abandoned", "relieved", "abrasive", "slope", "glistening", "afterthought", "plucky", "friends",
        "channel", "walk", "determined", "puzzled", "deserve", "stormy", "rate", "good", "ancient", "organic",
        "ratty", "draconian", "lettuce", "hate", "burly", "page", "flaky", "bake", "disagreeable", "yam",
        "inquisitive", "long-term", "befitting", "silent", "grandiose", "gaping", "hope", "uncovered",
        "pickle", "rice", "worried", "common", "sail", "zephyr", "plastic", "thunder", "practice", "slippery",
        "matter", "savory", "purring", "adjoining", "letter", "mindless", "bump", "cemetery", "bulb", "groan",
        "calculate", "piquant", "disillusioned", "pick", "marvelous", "rule", "quaint", "clammy", "afford", "worm",
        "purpose", "accidental", "flood", "stick", "rare", "destruction", "melted", "rhetorical", "measure", "spiky",
        "rain", "wish", "surprise", "noxious", "salt", "temper", "treat", "hook", "teaching", "wander", "advertisement",
        "trade", "test", "aromatic", "sock", "count", "loose", "quill", "mourn", "creator", "spark", "veil", "moan", "double",
        "kaput", "stroke", "beautiful", "stove", "chop", "exchange", "cover", "toy", "explode", "improve", "water", "astonishing",
        "consider", "gather", "use", "flippant", "pretty", "decay", "abortive", "sticks", "shape", "dare", "drum", "reward", "card",
        "end", "ludicrous", "confess", "please", "face", "quack", "laugh", "day", "connect", "tin", "growth", "complain", "testy",
        "root", "tasteless", "unarmed", "knowledgeable", "minister", "water", "throne", "devilish", "theory", "old-fashioned", "fair",
        "dogs", "mind", "frequent", "adamant", "recondite", "hellish", "memorize", "rock", "care", "arrive", "stupendous", "eager", "cough",
        "pumped", "petite", "hot", "chickens", "cars", "sniff", "digestion", "tight", "tease", "alluring", "juvenile", "solid", "wash", "hammer",
        "gusty", "woman", "wrench", "ripe", "stocking", "club", "morning", "limit", "agree", "spell", "umbrella", "lacking", "itchy", "tidy",
        "radiate", "smoke", "skip", "deliver", "whip", "boundless", "attempt", "elated", "tightfisted", "carpenter", "makeshift", "language",
        "appreciate", "downtown", "brush", "puffy", "approve", "challenge", "wealthy", "nondescript", "program", "hard-to-find", "tan", "protect",
        "attraction", "statuesque", "fit", "hurried", "stiff", "swift", "fancy", "oatmeal", "consist", "nappy", "spiteful", "trip", "nest", "marble",
        "pricey", "sugar", "cause", "self", "own", "talented", "hospital", "move", "cumbersome", "sail", "next", "scorch", "torpid", "support", "stew",
        "permit", "pretend", "goofy", "disagree", "teeny", "taboo", "yoke", "care", "peep", "title", "boundary", "faithful", "caption", "calm", "impolite",
        "twist", "health", "overflow", "wacky", "lip", "plug", "distinct", "dull", "dance", "apathetic", "thread", "debt", "grandfather", "material",
        "knife", "obtain", "turn", "vengeful", "tenuous", "punishment", "invent", "blue", "winter", "aloof", "suggest", "pray", "anxious", "squeeze", "mixed",
        "line", "caring", "squalid", "sheep", "lush", "death", "cross", "spray", "hot", "cable", "oceanic", "rough", "sordid", "knowledge", "mailbox",
        "point", "succinct", "station", "force", "utter", "recognize", "unequal", "bottle", "promise", "adhesive", "phobic", "dress", "plant", "box", "careful",
        "assorted", "volleyball", "jail", "increase", "vigorous", "smash", "direction", "zealous", "ski", "efficacious", "picayune", "aggressive", "soak",
        "squeak", "outgoing", "hulking", "obedient", "jump", "kitty", "wine", "meeting", "wait", "big", "possess", "tumble", "frantic", "scene", "fretful",
        "overjoyed", "ill-informed", "flesh", "distribution", "gentle", "curly", "rude", "instinctive", "order", "mist", "ball", "alike", "ship", "joke",
        "sore", "strap", "obeisant", "found", "last", "ossified", "level", "company", "purple", "handsomely", "ambiguous", "chicken", "snow", "achiever",
        "wash", "pull", "enormous", "best", "vanish", "snail", "craven", "shame", "twist", "bike", "electric", "amused", "work", "tug", "offer", "spooky",
        "flagrant", "fowl", "paste", "farm", "serve", "hard", "unruly", "market", "plants", "object", "wrap", "acrid", "fragile", "flower", "passenger",
        "absorbed", "terrify", "ghost", "cold", "grease", "hydrant", "harass", "measly", "earn", "pig", "appear", "fantastic", "dramatic", "truculent",
        "drip", "invincible", "bird", "neck", "elbow", "run", "cobweb", "sleet", "clam", "bouncy", "magnificent", "writing", "many", "building", "frail",
        "yard", "thirsty", "tearful", "misty", "bridge", "nice", "wealth", "reduce", "magic", "airplane", "whistle", "brown", "trucks", "shoe", "unnatural",
        "song", "thirsty", "label", "juggle", "credit", "industry", "connection", "abusive", "riddle", "nasty", "utopian", "plane", "little", "waves", "coil",
        "faded", "cooperative", "dam", "orange", "brake", "crayon", "warm", "instrument", "prevent", "return", "mellow", "chief", "wanting", "jobless", "screw",
        "scare", "thumb", "rule", "planes", "toothpaste", "protective", "noise", "rake", "entertain", "fresh", "ocean", "beds", "abstracted", "announce", "crash",
        "ill-fated", "cut", "plant", "agreeable", "metal", "early", "great", "berserk", "aboriginal", "true", "macabre", "hair", "lying", "right", "six", "beneficial",
        "parallel", "better", "mend", "milk", "shallow", "steadfast", "kettle", "supply", "steel", "snore", "broken", "absurd", "troubled", "suit", "ugliest", "mature",
        "tranquil", "thick", "join", "fade", "stitch", "giant", "punch", "jellyfish", "divide", "moon", "tense", "scary", "pull", "reminiscent", "look", "unwieldy", "mice",
        "functional", "door", "jolly", "lumpy", "suffer", "houses", "smile", "lovely", "gaze", "soup", "sponge", "miniature", "blue-eyed", "plantation", "selection", "order",
        "marry", "food", "print", "nest", "strong", "alcoholic", "sour", "hissing", "complete", "quicksand", "bedroom", "party", "rainstorm", "hospitable", "ruin", "nine",
        "painstaking", "clumsy", "interrupt", "land", "pipe", "acceptable", "reign", "account", "melodic", "tense", "cautious", "bright", "hill", "spicy", "smoke", "lunch",
        "peel", "start", "fold", "colorful", "education", "puzzling", "whispering", "escape", "ad hoc", "cabbage", "awake", "aunt", "reflect", "wing", "avoid", "advise",
        "face", "husky", "muddle", "chilly", "moaning", "keen", "crib", "fool", "record", "horse", "bomb", "ray", "nail", "frame", "multiply", "earthquake", "grey", "tiny",
        "nauseating", "paddle", "bury", "interest", "trust", "overt", "kindhearted", "cuddly", "fish", "knot", "fascinated", "roasted", "copper", "spiffy", "flock", "money",
        "file", "panicky", "toys", "include", "handle", "panoramic", "letters", "babies", "stitch", "thoughtless", "unable", "trick", "rub", "cooing", "interest", "attack",
        "living", "foamy", "obsequious", "scrawny", "cheat", "level", "evasive", "control", "yarn", "shock", "playground", "spotted", "boy", "sweltering", "use", "grip",
        "suspend", "lazy", "wistful", "ill", "capable", "curl", "jealous", "crook", "flowery", "irritating", "hollow", "tacit", "learn", "vein", "perfect", "idea", "collect",
        "hang", "distance", "battle", "needless", "transport", "refuse", "amusing", "carry", "limping", "fly", "dry", "last", "grubby", "pest", "live", "drawer", "birth", "left",
        "jumbled", "rich", "expert", "impulse", "public", "bead", "ground", "question", "scared", "mix", "ambitious", "snatch", "grass", "agreement", "cast", "incompetent", "even",
        "first", "remember", "wax", "dry", "question", "voice", "roll", "animal", "pack", "class", "huge", "same", "furniture", "agonizing", "habitual", "realize", "satisfying",
        "name", "can", "delight", "icky", "gratis", "oval", "rabbit", "ladybug", "sand", "march", "ignorant", "record", "squeal", "enchanting", "prefer", "x-ray", "nutty", "store",
        "witty", "grain", "fine", "bathe", "fire", "endurable", "tip", "stem", "possible", "discreet", "needle", "grandmother", "important", "box", "rhyme", "boorish", "knee",
        "greasy", "corn", "drain", "tart", "educated", "brief", "staking", "wren", "nation", "shop", "large", "quince", "plot", "curvy", "punish", "woebegone", "calculator", "observation",
        "heat", "defective", "funny", "famous", "cherries", "shade", "applaud", "rebel", "reach", "irate", "four", "stir", "madly", "exercise", "delicious", "decorate", "unkempt", "lame",
        "pies", "courageous", "locket", "liquid", "efficient", "mom", "snow", "steer", "axiomatic", "detail", "hilarious", "wholesale", "overconfident", "cakes", "wobble", "clap", "place",
        "religion", "icicle", "spill", "correct", "daily", "cheap", "vagabond", "short", "airport", "zoo", "energetic", "vest", "reflective", "illegal", "person", "sloppy", "frogs", "yak",
        "sprout", "ritzy", "committee", "amount", "grateful", "crooked", "close", "heap", "windy", "yell", "quiet", "cheese", "imported", "hurt", "quick", "cellar", "wiry", "black", "feigned",
        "well-off", "useless", "cake", "hall", "wandering", "sick", "cluttered", "incredible", "rescue", "quartz", "false", "collar", "skillful", "harmonious", "whole", "scattered", "weak",
        "quixotic", "numberless", "innate", "land", "communicate", "action", "air", "toothsome", "childlike", "insect", "wonder", "number", "exotic", "canvas", "house", "scratch", "abrupt", "late",
        "lumber", "spark", "note", "fluffy", "furry", "acidic", "drop", "eggnog", "moor", "erect", "red", "push", "trade", "bow", "expand", "groovy", "fold", "shop", "ugly", "aboard", "impossible",
        "lighten", "school", "sign", "meal", "workable", "fetch", "choke", "claim", "finger", "stale", "meaty", "clover", "educate", "raise", "match", "geese", "back", "occur", "ultra", "brash", "decisive",
        "clever", "clip", "pocket", "route", "fruit", "bushes", "identify", "voracious", "pear", "vivacious", "disapprove", "property", "detect", "parsimonious", "towering", "bounce", "heat", "honey",
        "possessive", "wretched", "materialistic", "behavior", "sound", "popcorn", "knotty", "snails", "condition", "lake", "move", "cynical", "enchanted", "smelly", "motion", "knowing", "flat", "watery",
        "chubby", "park", "territory", "egg", "wrong", "didactic", "coal", "snake", "system", "blink", "nostalgic", "wind", "accessible", "sack", "narrow", "bag", "demonic", "confuse", "vessel", "tangy", "tame",
        "unbecoming", "harmony", "sweater", "try", "toothbrush", "blushing", "carriage", "adjustment", "respect", "unlock", "silk", "competition", "damaged", "frightening", "worthless", "gullible", "vast",
        "retire", "abashed", "pathetic", "example", "tedious", "touch", "ten", "frightened", "ring", "board", "unite", "crow", "insurance", "likeable", "error", "employ", "youthful", "shelter", "talk", "suit",
        "zippy", "head", "acoustic", "bad", "hideous", "legal", "acoustics", "jam", "past", "happy", "smell", "train", "country", "wakeful", "railway", "aftermath", "brainy", "argument", "girls", "yellow", "year",
        "elfin", "instruct", "oafish", "believe", "furtive", "trousers", "awesome", "blind", "zany", "humor", "listen", "guarantee", "bare", "report", "delirious", "comparison", "stage", "donkey", "sparkling", "sweet",
        "small", "scrape", "shaggy", "encourage", "doll", "dispensable", "pale", "dust", "deep", "stamp", "notebook", "boat", "save", "eyes", "political", "woozy", "maniacal", "attach", "automatic", "subsequent",
        "rainy", "quilt", "science", "second-hand", "front", "old", "muscle", "explain", "available", "haircut", "help", "chess", "desert", "calendar", "divergent", "strengthen", "needy", "existence", "bucket",
        "adorable", "bite", "literate", "repair", "long", "basin", "love", "kill", "mine", "serious", "middle", "floor", "laborer", "rat", "empty", "sad", "rose", "dashing", "touch", "somber", "enthusiastic",
        "shrill", "alert", "laugh", "alleged", "uninterested", "uneven", "damage", "point", "lavish", "creepy", "spurious", "price", "selective", "sign", "desire", "able", "play", "balance", "brawny", "signal",
        "chase", "boast", "easy", "shiny", "peaceful", "innocent", "volcano", "ready", "ceaseless", "window", "miss", "curve", "actually", "wild", "tap", "trouble", "basket", "industrious", "lucky", "sincere",
        "friction", "word", "bath", "flame", "robust", "change", "open", "back", "time", "secretive", "inconclusive", "steady", "slow", "offer", "hushed", "rejoice", "awful", "loving", "square", "government",
        "cultured", "slap", "well-made", "behave", "part", "wry", "spy", "rabbits", "untidy", "trot", "idiotic", "mountainous", "subdued", "bless", "dust", "seal", "protest", "smell", "modern", "sneeze", "rely",
        "women", "volatile", "paint", "majestic", "lopsided", "pets", "embarrassed", "dead", "hour", "resolute", "ablaze", "minute", "ducks", "bell", "taste", "admire", "fear", "rapid", "probable", "massive",
        "shut", "store", "size", "cream", "attract", "deranged", "coach", "knot", "mess up", "moldy", "pedal", "petite", "untidy", "helpful", "daughter", "cough", "pump", "top", "sleepy", "skate", "scintillating",
        "base", "extra-large", "elite", "raspy", "full", "historical", "check", "chemical", "depend", "rush", "obsolete", "north", "successful", "shocking", "sip", "jelly", "finger", "placid", "girl", "inform", "attack",
        "pan", "force", "bore", "used", "afraid", "halting", "light", "excellent", "scarce", "income", "outrageous", "fuzzy", "fairies", "supreme", "influence", "leather", "mere", "spiders", "guarded", "arrange",
        "succeed", "frighten", "amusement", "satisfy", "pie", "act", "sedate", "zonked", "tire", "level", "twig", "new", "sticky", "note", "neighborly", "superficial", "thinkable", "strange",
        "complex", "pushy", "celery", "coat", "ban", "erratic", "secretary", "descriptive", "half", "show", "crazy", "team", "tick", "rhythm", "odd", "grouchy", "stomach", "macho", "fearless", "curtain", "squirrel",
        "rightful", "tank", "badge", "branch", "direful", "border", "tacky", "present", "poke", "languid", "wet", "irritate", "fixed", "obese", "partner", "imaginary", "verse", "type", "silky", "sound", "cows",
        "slip", "support", "camp", "puncture", "greedy", "guide", "jeans", "plant", "yawn", "thought", "sisters", "van", "fertile", "understood", "observant", "destroy", "billowy", "trite", "division", "sheet", "humorous",
        "guiltless", "tramp", "cagey", "post", "fat", "unequaled", "ashamed", "boot", "reaction", "muddled", "mark", "tangible", "space", "field", "healthy", "few",
        "afternoon", "sea", "color", "rings", "proud", "imagine", "blade", "temporary", "scrub", "heady", "brake", "paper", "excite", "name", "impress", "sister", "wreck", "offbeat", "search", "straight", "unaccountable",
        "blood", "mighty", "symptomatic", "breezy", "jewel", "tall", "grotesque", "high", "jazzy", "damaging", "gorgeous", "position", "blot", "fireman", "earth", "baseball", "ruddy", "annoyed", "walk",
        "request", "feeling", "amazing", "hateful", "simple", "elegant", "sneaky", "sulky", "pinch", "war", "rod", "cats", "fallacious", "excited", "toes", "hysterical", "brick", "fabulous", "receptive", "wiggly",
        "spotless", "grumpy", "home", "ask", "unknown", "glamorous", "roomy", "judge", "fire", "incandescent", "cushion", "rabid", "foolish", "tasty", "arch", "deafening", "smart", "pigs", "versed", "risk", "regret", "fog",
        "watch", "hobbies", "obscene", "dad", "garrulous", "queue", "tub", "abundant", "produce", "five", "sleep", "need", "unused", "branch", "mute", "shy", "rural", "watch", "steep", "threatening", "deadpan", "pointless",
        "remind", "difficult", "closed", "dangerous", "various", "therapeutic", "detailed", "square", "cute", "iron", "underwear", "concentrate", "vulgar", "bloody", "trap", "crate", "mouth", "encouraging", "tow", "bomb", "want", "dolls",
        "angle", "hose", "lackadaisical", "month", "continue", "tendency", "hurry", "battle", "cap", "shivering", "harsh", "aspiring", "bored", "turkey", "stereotyped", "allow", "lock", "monkey", "legs", "trains", "combative", "coherent",
        "bite-sized", "rampant", "curve", "yielding", "dapper", "meat", "beg", "excuse", "military", "unadvised", "view", "merciful", "graceful", "hug", "sidewalk", "murder", "fang", "saw", "songs", "giraffe", "roll", "tent",
        "ice", "orange", "ink", "sneeze", "wilderness", "unpack", "rot", "bolt", "eye", "apparel", "queen", "list", "borrow", "waste", "cattle", "development", "copy", "freezing", "doctor", "crime", "fuel", "shake", "room", "numerous",
        "unusual", "dislike", "jog", "scent", "zinc", "judicious", "intend", "work", "representative", "changeable", "value", "milk", "flow", "zip", "current", "trace", "weather", "onerous", "wail", "squash", "unsuitable", "longing", "overrated",
        "snakes", "night", "annoying", "glorious", "internal", "acid", "unique", "mammoth", "apologies", "pet", "lethal", "itch", "gigantic", "pollution", "aquatic", "power", "salty", "repulsive", "chance", "equable", "amuse", "separate", "cycle",
        "shoes", "oranges", "soft", "yummy", "test", "rest", "tooth", "trees", "lunchroom", "wasteful", "curious", "quizzical", "filthy", "shaky", "experience", "quiet", "dinosaurs", "crack", "general", "dysfunctional", "plate", "fearful",
        "tremble", "driving", "cart", "kind", "mate", "unhealthy", "pour", "turn", "immense", "drown", "cowardly", "amuck", "foregoing", "aberrant", "lonely", "stupid", "suck", "camera", "spring", "bear", "cloistered", "guess", "vague", "rock",
        "wriggle", "bleach", "provide", "relax", "bashful", "defeated", "perform", "color", "callous", "profuse", "discussion", "substantial", "familiar", "harm", "compete", "flimsy", "story", "office", "jumpy", "barbarous", "burn", "dazzling", "dime",
        "spare", "discovery", "mitten", "harbor", "remarkable", "arithmetic", "thoughtful", "low", "river", "accurate", "snotty", "busy", "match", "scribble", "island", "different", "travel", "cracker", "rotten", "dusty", "earsplitting", "prick",
        "tree", "learned", "quarter", "racial", "man", "knock", "books", "alarm", "glib", "slim", "one", "stream", "sin", "heartbreaking", "royal", "scientific", "engine", "lock", "disarm", "judge", "anger", "pencil", "perpetual", "envious", "entertaining",
        "load", "undress", "enjoy", "marked", "permissible", "typical", "waste",
        "circle", "reason", "event", "memory", "string", "worry", "spot", "scream", "giants", "voiceless", "range", "fork", "doubtful", "lean", "dirty", "grab", "fortunate", "visit", "evanescent", "pink", "charge", "sturdy", "plausible", "opposite", "ruthless",
        "toe", "mine", "wooden", "tour", "release", "venomous", "inject", "rinse", "plough", "brass", "young", "whirl", "wicked", "dinner", "guttural", "nifty", "surprise", "smoggy", "tiger", "minor", "bent", "nebulous", "imminent", "nervous", "button", "grieving",
        "vegetable", "road", "birthday", "glue", "like",
        "noiseless", "shelf", "interfere", "heavenly", "scarf", "uppity", "slave", "ajar", "cool", "quirky", "messy", "depressed", "hand", "plan", "art", "trail", "trashy", "chalk", "tawdry", "swim", "defiant", "delay", "prickly", "selfish", "hands",
        "adventurous", "icy", "stop", "tiresome", "sink", "stingy", "soggy", "step", "carve", "thundering", "follow", "bikes", "skirt", "suggestion", "boiling", "phone", "way", "book", "stretch", "gabby", "steam", "hungry", "balance", "romantic", "separate", "men",
        "pancake", "receipt", "naive", "righteous", "texture",
        "tough", "fancy", "nonstop", "request", "gruesome", "advice", "weary", "superb", "jump", "capricious", "meek", "horn", "murky", "spectacular", "whine", "comfortable", "fax", "glove", "flawless", "embarrass", "slimy", "rustic", "tender", "auspicious",
        "obey", "mug", "cheerful", "wonderful", "average", "wide-eyed", "handsome", "tempt", "certain", "belong", "pleasure", "parcel", "thankful", "tasteful", "premium", "scale", "loss", "statement", "society", "cook", "horses", "grade", "wool",
        "clean", "insidious", "tested", "hanging", "guard", "surround", "economic",
        "ticket", "command", "look", "gaudy", "subtract", "intelligent", "wave", "wink", "quarrelsome", "whimsical", "chew", "classy", "kindly", "precede", "tomatoes", "spade", "ear", "baby", "puny", "hope", "squealing", "oven", "pizzas", "preserve", "skin", "hammer",
        "nonchalant", "sassy", "linen", "scandalous", "head", "increase", "meddle", "tricky", "dock", "shade", "trick", "knit", "exuberant", "two", "berry", "cup", "dreary", "dusty", "momentous", "feeble", "silent", "tie", "future", "dress", "telephone", "present", "glossy", "church", "arm", "flower", "special",
        "condemned", "bitter", "fail", "fix", "jagged", "daffy", "disappear", "frame", "press", "reading", "cat", "sparkle", "nimble", "safe", "quickest", "forgetful", "resonant", "optimal", "seemly", "pastoral", "throat", "wrathful", "clear", "humdrum", "previous",
        "nut", "mundane", "rambunctious", "smiling", "soda", "shirt", "penitent", "sore", "drop", "notice", "writer", "thaw", "bumpy", "responsible", "pen", "number", "wide", "synonymous", "private", "change", "gray", "invite", "terrific", "crush", "sun", "zebra", "splendid", "place", "smooth", "friendly", "exclusive",
        "ethereal", "beef", "smile", "fasten", "jam", "valuable", "table", "disgusted", "tickle", "shrug", "crowded", "hallowed", "bit", "heavy", "arrest", "happen", "man", "highfalutin", "call", "payment", "observe", "polish", "rain", "joyous", "rifle", "reproduce",
        "green", "addicted", "nose", "bawdy", "unwritten", "wary", "elderly", "zipper", "broad", "drag", "plain", "godly", "colossal", "rub", "omniscient", "guide", "prose", "group", "birds", "poor", "thank", "crown", "uptight", "pat", "imperfect", "attend", "answer",
        "cub", "crack", "receive", "boring", "key", "magenta",
        "ahead", "abject", "pop", "loutish", "kneel", "vacuous", "stone", "bait", "manage", "sharp", "well-groomed", "grin",
        "juice", "wall", "fact", "chunky", "discover", "grate", "bat", "straw", "medical", "fast", "stimulating", "compare", "breathe", "admit", "alive", "concern", "swing", "squeamish", "pot", "warlike", "melt", "edge", "dog", "bat", "delicate", "paltry", "fry", "crabby",
        "stretch", "far-flung", "laughable", "unfasten", "lively", "kittens", "apparatus", "slip", "replace", "star", "wipe", "giddy", "deeply", "chin", "thrill", "aware", "offend", "loud", "warn", "loaf",
        "week", "extra-small", "clean", "gleaming", "jail", "servant", "push", "glow", "bee", "snobbish", "blow", "addition", "silver", "verdant", "upset", "swanky", "haunt", "wheel", "float", "shock", "argue", "cannon", "launch", "round", "poised", "elastic",
        "uttermost", "hesitant", "productive", "near", "thin", "terrible", "recess", "treatment", "blush", "decorous", "holiday", "hypnotic", "unbiased", "mother", "warm", "sigh", "abaft", "ubiquitous", "victorious", "produce", "like", "regular", "spoon",
        "flash", "spot", "degree", "appliance", "far", "leg", "stare", "psychotic",
        "charming", "sudden", "silly", "lyrical", "eight", "suspect", "cause", "gun", "conscious", "beam", "analyst", "train", "polite", "vacation", "book", "lick", "fanatical", "cave", "concerned", "grip", "jar", "voyage", "stranger", "low", "peace", "kiss", "roof", "simplistic",
        "things", "hook", "scarecrow", "nippy", "fear", "film", "nerve", "shave", "white", "basketball", "diligent", "children", "scissors", "smash", "share", "trip", "tame", "hop", "repeat", "add", "upbeat", "pleasant", "disastrous", "bed", "eatable", "screw", "suppose", "picture", "mysterious", "necessary",
        "kick", "wave", "standing", "nutritious", "womanly", "hover", "coil", "rob", "bubble", "end", "switch", "toad", "start", "hat", "abhorrent", "part", "exciting", "kick", "delightful", "time", "unsightly", "race", "hum", "mountain", "introduce", "juicy", "aback", "glass", "grape",
        "dark", "overwrought", "quiver", "profit", "waggish", "sort", "married", "crawl", "noisy", "wire", "accept", "creature", "design", "malicious", "bang", "male", "ants", "flashy", "black-and-white", "damp", "natural", "beginner", "authority", "tail", "buzz", "decide", "magical", "mark", "lamp",
        "holistic", "bustling", "prepare", "preach", "questionable", "coordinated", "wound", "fierce", "fall", "ignore", "whisper", "clear", "outstanding", "whip", "exist", "teeny-tiny", "gainful", "contain", "well-to-do", "precious", "seashore", "boil", "license", "obnoxious",
        "annoy", "abnormal", "activity", "jittery", "inexpensive", "calculating", "interesting", "desk", "dependent", "thing", "tray", "governor", "ordinary", "sense", "labored", "willing", "dream", "lewd", "lamentable", "sack", "brother", "heal", "gold", "strip", "careless", "step", "play", "wish", "slow",
        "flap", "real", "bizarre", "seed", "machine", "unit", "female", "skinny", "absorbing", "maid", "join", "null", "earthy", "faint", "free", "soothe", "mushy", "develop", "mass", "pass", "abiding", "foot", "shiver", "stamp", "actor", "butter", "long", "invention", "side", "lie", "form", "love",
        "bright", "dear", "angry", "soap", "camp", "coast", "powerful", "stop", "regret", "eggs", "spiritual", "fill", "parched", "bells", "bubble", "measure", "army", "curved", "cover", "town", "rail", "sofa", "cactus", "helpless", "chivalrous", "cloudy", "truck", "infamous", "burst",
        "stain", "tremendous", "effect", "faulty", "owe", "structure", "approval", "homely", "gamy", "alert", "tax", "brave", "maddening", "open", "robin", "greet", "flavor", "normal", "reply", "obtainable", "extend", "taste", "bruise", "doubt", "drain", "duck", "absent", "need", "bewildered", "deceive",
        "history", "pause", "oil", "talk", "truthful", "finicky", "pin", "relation", "belief", "summer", "enter", "scold", "rigid", "cute", "hand", "deserted", "fluttering", "gate", "friend", "uncle", "library", "telling", "striped", "sophisticated", "cure", "mask", "weight", "mint",
        "car", "equal", "spotty", "drab", "wise", "handy", "fumbling", "empty", "dizzy", "nosy", "expansion", "psychedelic", "pine", "hunt", "comb", "breath", "neat", "confused", "ragged", "violet", "second", "hapless", "super", "porter", "cry", "impartial", "physical", "kiss", "describe",
        "known", "whistle", "mean", "waiting", "cloth", "powder", "third", "stuff", "deer", "bone", "transport", "decision", "tongue", "useful", "drink", "seat", "cent", "lace", "domineering", "gifted", "luxuriant", "crowd", "lowly", "cherry", "scatter", "eminent", "flowers", "remove",
        "honorable", "weigh", "fence", "miscreant", "nod", "plastic", "peck", "animated", "visitor", "painful", "injure", "breakable", "tired", "son", "festive", "debonair", "adaptable", "undesirable", "zesty", "hate", "potato", "sable", "guitar", "stay", "secret", "remain", "reject", "coach",
        "zoom", "vase", "dynamic", "form", "spoil", "cruel", "complete", "naughty", "futuristic", "wrist", "redundant", "exultant", "violent", "wrestle", "flight", "welcome", "horrible", "expect", "screeching", "disturbed", "pail", "pump", "arrogant", "cheer", "sky", "expensive",
        "belligerent", "poison", "motionless" };
    #endregion 


    protected void Page_Load(object sender, EventArgs e)
    {//Phase A
        if(Session["user"] == null)
        {//bouncer check
            Response.Redirect("Login.aspx");
        }

        if(!IsPostBack)
        {
            ResetGame();

        }

        //tbGuessChar.Text = ""; // reset the guess box
    }

    

    private void ResetGame()
    {
        Random rand = new Random();
        GameInfo gi = new GameInfo();
        if(Session["user"] !=null)
        {
            UserInfo ui = (UserInfo)Session["user"];


            bool repeatedChars = true;
            do
            {//roll dice multiple times if Hard or Nightmare mode, to find word with no repeat chars
                int r = rand.Next(0, words.Length); // dice rolle a random index into the array of words    
                gi.Hidden = words[r]; // get me the hidden word
                repeatedChars = Check4Repeat(gi.Hidden);
            }
            while (repeatedChars == true && (ui.Difficulty == Level.Hard || ui.Difficulty == Level.Nightmare));



            tbHidden.Text = ""; // 1st clear out any previous word
            for (int i = 0; i < gi.Hidden.Length; i++)
            { // add an * for every char in the hidden word
                tbHidden.Text += "*";
            }
            if (Session["user"] != null)
            {

                if (ui.Difficulty == Level.Easy)
                {
                    gi.TriesRemaining = 3 * gi.Hidden.Length; // allow twice as many chars for their tries
                }
                else if (ui.Difficulty == Level.Medium)
                {
                    gi.TriesRemaining = 2 * gi.Hidden.Length; // allow twice as many chars for their tries
                }
                else if (ui.Difficulty == Level.Hard)
                {
                    gi.TriesRemaining = (int)1.5 * gi.Hidden.Length; // allow twice as many chars for their tries
                }
                else
                {
                    gi.TriesRemaining = 1 * gi.Hidden.Length; // allow twice as many chars for their tries
                }
            }
        }





       
        Session["gameInfo"] = gi; // store game object in the Session
    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {//Phase B
        Session["user"] = null;
        Response.Redirect("Login.aspx");

    }

    protected void btnGuess_Click(object sender, EventArgs e)
    {//Phase B

        if(Session["gameInfo"] == null)
        {
            ResetGame();
            btnGuess.Text = "Go!";
        }

        if(tbGuessChar.Text.Length == 1)
        {
            char c = tbGuessChar.Text.ToLower()[0];
            GameInfo gi = (GameInfo)Session["gameInfo"];
            if (gi.TriesRemaining > 0)
            {
                if (gi.Attempts.Contains(c))
                {
                    lblWelcome.Text = "You already guessed that!";
                }
                else
                {
                    gi.Attempts.Add(c); // add the new attempted char to the list
                    gi.TriesRemaining--; // decrement their tries by 1
                    Session["gameInfo"] = gi; // put updated gameInfo object back into Session
                }
            }
            else
            {
                lblWelcome.Text = "Sorry, out of guesses!";
            }

        }
        tbGuessChar.Text = "";

    }

    protected void Page_PreRender(object sender, EventArgs e)
    {//Phase C
        UserInfo ui = (UserInfo)Session["user"];
        lblWelcome.Text = "Hello, " + ui.Username + "!";

        GameInfo gi = (GameInfo)Session["gameInfo"];
        lblTries.Text = "Tries remaining: " + gi.TriesRemaining;
        tbAlready.Text = "";

        foreach (char c in gi.Attempts)
        {
            // add in all attempted chars...
            tbAlready.Text += c + ", ";
        }

        tbHidden.Text = "";
        int count = 0;
        foreach (char c in gi.Hidden.ToLower())
        {
            if (gi.Attempts.Contains(c))
            {
                tbHidden.Text += c;
                count++;

            }
            else
            {
                tbHidden.Text += "*";
            }
        }

        if (count == gi.Hidden.Length)
        { // Victory
            lblWelcome.Text = "You won! Play again?";
            btnGuess.Text = "Replay";
            Session["gameInfo"] = null;

        }
        else if (gi.TriesRemaining <= 0 && count < gi.Hidden.Length)
        {
            lblWelcome.Text = "Sorry, you lost! The word was: " + gi.Hidden;
            btnGuess.Text = "Replay";
            Session["gameInfo"] = null; // remove game from session, cuz its over

        }

    }
   /// <summary>
   /// Function to determine if the word has repeated chars
   /// </summary>
   /// <param name="word">the hidden word to be checked</param>
   /// <returns>True if it finds a repeated char in the word</returns>
   protected bool Check4Repeat(string word)
   {
        List<char> copies = new List<char>();
        foreach(char c in word)
        {
            for(int i = copies.Count; i > 0; i--)
            {
                if(c == copies[i-1])
                {
                    return true;
                }
            }
            copies.Add(c);
        }
        return false;
    }
    
}