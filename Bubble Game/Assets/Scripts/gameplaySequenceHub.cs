using System.Collections.Generic;
using UnityEngine;

public class GameplaySequenceHub : MonoBehaviour {
    public static GameplaySequenceHub instance;
    public string playerName = "<color=#8800AA>You: </color>";

    public Dictionary<int, string[]> dayScene = new Dictionary<int, string[]> {
        {1, new string[] {
            "Finally, a new untapped market... I've made it!",
            "The big city was too competitive, every human already knows the delicacy that is...",
            "BUBBLE TEA!",
            "But here in Magskjoldr, there's a ton of creatures who've never tasted the drink of the gods!",
            "Finally, I can make the gold I always deserved and rule a boba empire! Mwahah--",
            "Good thing I have my handy <color=#0088AA>Guidebook</color> if I get stuck making an order. Maybe I should look at it now...",
            "Oh look!, my first customer!"}
        },
        {2, new string[] {
            "I'm not getting as many customers as I was hoping...",
            "And if they don't like my drinks, they don't pay!",
            "If it keeps up, I'll be out of business in no time!",
            "I need to set a goal.",
            "Let's be reasonable: if I can earn <color=#E9B300>100 gold</color> by the end of the week, I'm sure I can convince the townspeople that The Boba Tavern should be here to stay!"}
        },
        {3, new string[] {
            "The third day and you know what they say, third time's the charm! I'm sure by the end of the day, I'll convince the creatures of this town that The Boba Tavern is here to stay!"}
        },
        {4, new string[] {
            "It's already day 4... I'm halfway through the week.",
            "I'm sure by now news has spread to the Fairies so I can add the Fruit Tea base for them.", 
            "And I've just received new stock!",
            "For customers who want something <color=#0088AA>Intense</color>, I can add <color=#0088AA>Dragon Tears</color> and to make the Bubble Tea <color=#0088AA>Fluffy</color>, I should add <color=#0088AA>Pixie Clouds</color>.",
            "Okay, let's do this!"}
        },
        {5, new string[] {
            "Alrighty, it's the fifth day! I feel pumped with the dwarf tavern owner's talk and he's right, I gotta keep going! Let's make today a good one!"}
        },
        {6, new string[] {
            "The sixth day... just one more day after this. I gotta keep up the momentum and make sure I finish strong!",
            "Demons might start coming by so I should serve the Black Tea base for them.", 
            "The last stock for my toppings have also arrive now.",
            "For customers who want something <color=#0088AA>Novel</color>, I need to add the <color=#0088AA>Sunbeam Jelly</color> topping and to create a <color=#0088AA>Calming</color> effect, I would need some <color=#0088AA>Magic Beans</color>.",
            "Got it, I can do it!"}
        },
        {7, new string[] {
            "The last day! I've worked so hard this week and have served so many customers... now it's time to use everything I've learned for this last push!",
            "I need to reach <color=#E9B300>100 gold</color>"}
        }
    };

    public Dictionary<string, string[]> outroScene = new Dictionary<string, string[]> {
        {"1S", new string[] {
            "Oh man, it's already evening! I guess it's time to close up.",
            "I remember back in the big city, when I mostly had successful orders during the day, the customers would recommend me to other customers who would submit more complex orders!",
            "And with each additional topping in the order, they would give one additional gold and that got me closer to reaching my goal!",
            "But when I messed up orders, they wouldn't give me any gold. And if I failed more orders than I succeeded, the orders would become more simple and it got harder to reach my goal...",
            "and that's why I'm here now! So let's set a reasonable goal: if I can earn 100 gold by the end of the week, I'm sure I can convince the townspeople that The Boba Tavern should be here to stay!",
            "Alright, let's do our best to win the town over with... BUBBLE TEA!"
            }
        },
        {"1F", new string[] {
            "Oh man, it's already evening! I guess it's time to close up.",
            "I remember back in the big city, when I mostly had successful orders during the day, the customers would recommend me to other customers who would submit more complex orders!",
            "And with each additional topping in the order, they would give one additional gold and that got me closer to reaching my goal!",
            "But when I messed up orders, they wouldn't give me any gold. And if I failed more orders than I succeeded, the orders would become more simple and it got harder to reach my goal...",
            "and that's why I'm here now! So let's set a reasonable goal: if I can earn 100 gold by the end of the week, I'm sure I can convince the townspeople that The Boba Tavern should be here to stay!",
            "Alright, let's do our best to win the town over with... BUBBLE TEA!"
            }
        },
        {"2S", new string[] {
            "Y/N: Yes! It looks like I succeeded on most of my orders today, we're off to a great start!",
            "Orc: HEY HUMAN!",
            "Y/N: Ah, sorry, we're closed!",
            "Orc: I AIN'T HERE FOR YER BOBBLE TEA! JUST HERE TO SEE HOW THINGS ARE DOIN' AND FROM THE LOOKS OF IT, YER DOIN' PRETTY WELL FOR YERSELF!",
            "Y/N: Yup, today seems to be a success!",
            "Orc: WELL KEEP UP THE GOOD WORK! SEEMS THE TOWNSPEOPLE ARE SATISFIED AND THEY'LL START THROWIN' HARDER ORDERS AT'CHA! SEE YA AROUND!",
            "Y/N: Maybe he's nicer than I thought...?"
            }
        },
        {"2F", new string[] {
            "Y/N: Aw man... not looking too hot already, I failed more orders than I wanted today...",
            "Orc: HEY HUMAN!",
            "Y/N: Ah, sorry, we're closed!",
            "Orc: I AIN'T HERE FOR YER BOBBLE TEA! JUST HERE TO SEE HOW THINGS ARE DOIN' AND FROM THE TOWNSPEOPLE BEEN SAYIN', SOUNDS LIKE YA KEPT MESSING UP!",
            "Y/N: Yeah... seems I failed today.",
            "Orc: WELL CHIN UP, I DIDN'T GIVE YA THE GO AHEAD FOR NOTHING. TOMORROW THE ORDERS WILL PROBABLY BE SIMPLE BUT IF YA IMPROVE AND GET THE TOWNSPEOPLE SATISFIED, THEY'LL START THROWIN' HARDER ORDERS AT'CHA! GOTTA GET GOIN' NOW, SEE YA!",
            "Y/N: Maybe he's nicer than I thought...?"
            }
        },
        {"3S", new string[] {
            "Y/N: Great work! I'm sure I'm the talk of the town by now!",
            "Elf: Well, hello dear human. I must say you've been creating quite a buzz in town.",
            "Y/N: Sorry, who are you?",
            "Elf: I'm the chieftain of this town. I've heard of you from my colleague and it seems you are doing quite well for yourself. It seems even the fairies will start stopping by tomorrow.",
            "Y/N: Thanks! And you're right, business is going great!",
            "Elf: I look forward to see just how successful you manage to be. After all, like my colleague said, failure will spell the end of your little tavern in our town.",
            "Y/N: ... Scary..."
            }
        },
        {"3F", new string[] {
            "Y/N: Today didn't turn out how I expected... I'll probably be the talk of the town for the wrong reasons...",
            "Elf: Well, hello dear human. I must say you've been creating quite a buzz in town.",
            "Y/N: Sorry, who are you?",
            "Elf: I'm the chieftain of this town. I've heard of you from my colleague and it seems you are doing... not as ideally as you anticipated. Though it seems the fairies will start stopping by tomorrow even so.",
            "Y/N: Ouch... thanks for rubbing that in.",
            "Elf: I do hope you manage to pick things up a little. After all, like my colleague said, failure will spell the end of your little tavern in our town and from the looks of it, that may be soon.",
            "Y/N: ... Scary..."
            }
        },
        {"4S", new string[] {
            "Y/N: Nice nice! I killed it today!",
            "Dwarf: Howdy neighbour! Closin' up shop I see!",
            "Y/N: Is this gonna happen everyday...? Yup! And you are...?",
            "Dwarf: Ah, I run the tavern down the street and just wanted to say you're doin' great work! Love to see hard workin' young'uns around these parts.",
            "Y/N: Wow, thanks! Really appreciate the support!",
            "Dwarf: Around these here parts, we should help each other, right? I remember back when I started out, things weren't easy but you'll get the hang of it, good luck!",
            "Y/N: ... I think I'm starting to really like it around here!",
            }
        },
        {"4F", new string[] {
            "Y/N: Yikes... that was tough today.",
            "Dwarf: Howdy neighbour! Closin' up shop I see!",
            "Y/N: Is this gonna happen everyday...? Yup! And you are...?",
            "Dwarf: Ah, I run the tavern down the street and just wanted to send some encouragement seein' as the goin's tough! Love to see hard workin' young'uns around these parts.",
            "Y/N: Thanks... I needed the pep talk.",
            "Dwarf: Ah, don't sweat one or two bad days. I remember back when I started out, things weren't easy but you'll get the hang of it, good luck!",
            "Y/N: ... I think I'm starting to really like it around here!"
            }
        },
        {"5S", new string[] {
            "Y/N: Great! At this rate, I'm on track!",
            "Fairy: Heehee, WEEEEE!",
            "Y/N: What the- Hey careful careful!",
            "Fairy: Oopsies, sorry teehee! I just wanted to stop by as a patron and say... you're doing GREAT!!",
            "Y/N: Oh, uh, thanks...? Appreciate the support.",
            "Fairy: ANYWAYS, hope you keep it up! A lot of my friends like your human concoctions so it'd be a shame to see you go. Oh, also, I heard the demons will start coming tomorrow! BYEEE WEEEEE!",
            "Y/N: ... Huh."
            }
        },
        {"5F", new string[] {
            "Y/N: Oh no... looks like I'm off track.",
            "Fairy: Heehee, WEEEEE!",
            "Y/N: What the- Hey careful careful!",
            "Fairy: Oopsies, sorry teehee! I just wanted to stop by as a patron and say... you're doing TERRIBLE!!",
            "Y/N: Oh, uh, I don't know what to say...?",
            "Fairy: ANYWAYS, you better get it together! At this rate, you won't last the week and that'd be a shame... for you. Oh, also, I heard the demons will start coming tomorrow! BYEEE WEEEEE!",
            "Y/N: ... Huh."
            }
        },
        {"6S", new string[] {
            "Y/N: Yes! I'm confident I'll make it to my goal!",
            "Demon: Human... Good day...",
            "Y/N: AH- O-oh, hello there!",
            "Demon: Yes... I must say my brethren are impressed... it takes much effort to calm our demon instincts...",
            "Y/N: I-I'm glad to be of service to the townspeople!",
            "Demon: I hope you can continue your efforts... otherwise, it may not just be your little tavern that meets its demise...",
            "Y/N: ... Sounds like I have no choice but to succeed."
            }
        },
        {"6F", new string[] {
            "Y/N: Argh, I'm not sure if I'll make it to my goal...",
            "Demon: Human... Good day...",
            "Y/N: AH- O-oh, hello there!",
            "Demon: No... I must say my brethren are disappointed... we expected more from your human concoctions...",
            "Y/N: I-I'm sorry to hear that...",
            "Demon: I hope you can improve your efforts... otherwise, it may not just be your little tavern that meets its demise...",
            "Y/N: ... Sounds like I have no choice but to succeed."
            }
        }
    };

    private void Awake() { // making things singleton
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else if (instance != this) {
            Destroy(this);
        }
    }
}
