using System;
using PizzaDataN;


namespace OrderBot
{
    public class Order
    {
        PizzaData pizzaData = new PizzaData(); //To get data from database
        String[] userOrder = new String[6]; //To remind user

        private int step = 0;

        private enum State
        {
            WELCOMING, STARTING
        }

        private State nCur = State.WELCOMING;

        public Order()
        {
           
        }

        public void SetStep(int step)
        {
            this.step = step;
        }

        public String OnMessage(String sInMessage)
        {
            //String sMessage = "";
            String sMessage = "Welcome to Pizza World, Make your own pizza!";
            sMessage = sMessage + "\n" + "Do you want to order? (yes/no)";
            switch (this.nCur)
            {
                case State.WELCOMING:
                    this.nCur = State.STARTING;
                    break;

                case State.STARTING:
                    
                        sInMessage = sInMessage.ToLower().Trim();

                        if(sInMessage == "back")
                        {
                            if(this.step >= 2)
                            {
                                this.step--;

                                sMessage = pizzaData.GetPizzaData(this.step);

                                if(this.step == 7)
                                {
                                    sMessage = sMessage + makeOrderHistory();
                                }
                                
                                return sMessage;
                            }
                            else
                            {
                                sMessage = "Cannot go to previous step!\n";
                            }
                            
                        }
                    
                        switch(this.step)
                        {
                            case 0: //start order answer y/n
                                if(sInMessage == "yes" || sInMessage == "y" )
                                {
                                    this.step++;
                                    sMessage = pizzaData.GetPizzaData(this.step);
                                    break;    
                                }
                                else
                                {
                                    this.step = 0;
                                    this.nCur = State.WELCOMING;
                                    sMessage = "See you next time.";
                                    break;
                                }
                            case 1: //size answer
                                if(sInMessage.Contains("small") || sInMessage.Equals("1") ||
                                    sInMessage.Contains("medium") || sInMessage.Equals("2") ||
                                    sInMessage.Contains("large") || sInMessage.Equals("3")) 
                                {
                                        this.step++;
                                        this.userOrder[0] = "[size] " + sInMessage;
                                        sMessage = pizzaData.GetPizzaData(this.step);
                                        break;
                                }
                                else
                                {
                                    sMessage = sMessage + "Please re-enter.\n" + pizzaData.GetPizzaData(this.step);
                                    break;
                                }
                            case 2: //dough answer
                                if(sInMessage.Contains("regula") || sInMessage.Equals("1") ||
                                    sInMessage.Contains("whole wheat") || sInMessage.Equals("2") ||
                                    sInMessage.Contains("gluten free multigrain") || sInMessage.Equals("3")) 
                                {
                                        this.step++;
                                        this.userOrder[1] = "[dough] " + sInMessage;
                                        sMessage = pizzaData.GetPizzaData(this.step);
                                        break;
                                }
                                else
                                {
                                    sMessage = "Please re-enter.\n" + pizzaData.GetPizzaData(this.step);
                                    break;
                                }
                            case 3: //crust answer
                                if(sInMessage.Contains("regula") || sInMessage.Equals("1") ||
                                    sInMessage.Contains("thin") || sInMessage.Equals("2") ||
                                    sInMessage.Contains("thick") || sInMessage.Equals("3")) 
                                {
                                        this.step++;
                                        this.userOrder[2] = "[crust] " + sInMessage;
                                        sMessage = pizzaData.GetPizzaData(this.step);
                                        break;
                                }
                                else
                                {
                                    sMessage = "Please re-enter.\n" + pizzaData.GetPizzaData(this.step);
                                    break;
                                }   
                            case 4: //sauce answer
                                if(sInMessage.Contains("tomato") || sInMessage.Equals("1") ||
                                    sInMessage.Contains("bbq") || sInMessage.Equals("2") ||
                                    sInMessage.Contains("pesto") || sInMessage.Equals("3")) 
                                {
                                        this.step++;
                                        this.userOrder[3] = "[sauce] " + sInMessage;
                                        sMessage = pizzaData.GetPizzaData(this.step);
                                        break;
                                }
                                else
                                {
                                    sMessage = "Please re-enter.\n" + pizzaData.GetPizzaData(this.step);
                                    break;
                                }
                            case 5: //topping answer
                                if(sInMessage.Contains("pepperoni") || sInMessage.Equals("1") ||
                                    sInMessage.Contains("bacon") || sInMessage.Equals("2") ||
                                    sInMessage.Contains("chicken") || sInMessage.Equals("3") ||
                                    sInMessage.Contains("beef") || sInMessage.Equals("4") ||
                                    sInMessage.Contains("mushrooms") || sInMessage.Equals("5") ||
                                    sInMessage.Contains("pineapple") || sInMessage.Equals("6"))
                                {
                                        this.step++;
                                        this.userOrder[4] = "[topping] " + sInMessage;
                                        sMessage = pizzaData.GetPizzaData(this.step);
                                        break;
                                }
                                else
                                {
                                    sMessage = "Please re-enter.\n" + pizzaData.GetPizzaData(this.step);
                                    break;
                                }   
                            case 6: //etc answer
                                if(sInMessage.Contains("caesar salad") || sInMessage.Equals("1") ||
                                    sInMessage.Contains("chips") || sInMessage.Equals("2") ||
                                    sInMessage.Contains("coke") || sInMessage.Equals("3") ||
                                    sInMessage.Contains("water") || sInMessage.Equals("4"))
                                {
                                        this.step++;
                                        this.userOrder[5] = "[etc] " + sInMessage;
                                        
                                        sMessage = pizzaData.GetPizzaData(this.step) + "\n";

                                        
                                        sMessage = sMessage + makeOrderHistory();
                                        break;
                                }
                                else
                                {
                                    sMessage = "Please re-enter.\n" + pizzaData.GetPizzaData(this.step);
                                    break;
                                }   
                            case 7: //remind order answer
                                if(sInMessage == "yes" || sInMessage == "y" )
                                {
                                        this.step++;
                                        
                                        sMessage = pizzaData.GetPizzaData(this.step);
                                        break;
                                }
                                else
                                {
                                    sMessage = "Please re-enter. [yes] or [back]";
                                    break;
                                }   
                            case 8: //address answer
                                this.step++;
                                sMessage = "Please pay at http://localhost:5000/payment \n\nAfter payment is completed, enter any key.";
                                break;
                            case 9: //complete
                                this.step = 0;
                                this.nCur = State.WELCOMING;
                                sMessage = "Thank you for your pizza order. See you again";
                                break;
                        }
                    
                    break;
            }
            return sMessage;
        }

        public String makeOrderHistory()
        {
            String sMessage ="";
            for(int i=0; i<this.userOrder.Length; i++)
            {
                sMessage = sMessage + this.userOrder[i] + "\n";                                    
            }
            sMessage = sMessage + "Is your order correct?\nIf so, enter \"yes\"\nIf not so, enter \"back\" to go back to the previous task.";
            return sMessage;
        }
    }
}
