import { Component, OnInit } from '@angular/core';
import { User } from '../user';


@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit {
  
  counter = 0;
  membershipID="";
  newUser = new User(1,'a','b','c','d','e','f','g','h','i','j','k','l',false,2,3,'m',[],[],[],[],false,4,'r',5);

  year:string[] = ["Freshman","Sophomore","Junior","Senior","Grad Masters","Grad PHD","Professor","Alumni","Other"];
  commute:string[]=["Live on Campus", "Walking Distance", ">30 min", ">1 hour","Other"];
  
  interest:string[]=["Security","Visualization","Computer Human Interaction","Machine Learning","Education","Mathematics","Scalable Computing"];
  sigs:string[]=["SysAdmin","BlockChain","Algorithmic Trading","Math","Windows"];
  majorEvents:string[]=["Flourish!(An open source conference run by LUG and ACM student Orgs)",
                       "Hackathon",
                       "IT D3bug Challenges",
                       "Programming Challenges",
                       "Reflection Projection"
                      ];
  competition:string[]=["Hack Illinois",
                      "ICPC programming competition",
                      "Google Tech Challenge",
                      "Loyola Datafest",
                      "DOE Cyberforce Competition"
                      ];
  intere = new Array(this.interest.length+1);
  sig = new Array(this.sigs.length);
  majorEven = new Array(this.majorEvents.length);
  competit = new Array(this.competition.length);
  interestoption = false;
  interestValue="";
  
  makeInterest(){
    for(let i=0;i<this.interest.length;i++){
      if(this.intere[i]){
        this.newUser.interestInCS.push(this.interest[i] );
      }
    }
    if(this.intere[this.intere.length-1]){
      this.newUser.interestInCS.push(this.interestValue);
    }
  }
  makeSigs(){
    for(let i=0;i<this.sigs.length;i++){
      if(this.sig[i]){
        this.newUser.sigs.push(this.sigs[i] );
      }
    }
  }
  makeEvents(){
    for(let i=0;i<this.majorEvents.length;i++){
      if(this.majorEven[i]){
        this.newUser.majorEvent.push(this.majorEvents[i] ); 
      }
    }
  }
  makeCompetition(){
    for(let i=0;i<this.competition.length;i++){
      if(this.competit[i]){
        this.newUser.competing.push(this.competition[i])
      }
    }
  }
  nextCounter(num){
    console.dir(num);
    this.counter++;
  }
  backCounter(){
    this.counter--;
  }
  onSubmit(){
    this.makeInterest();
    this.makeSigs();
    this.makeEvents();
    this.makeCompetition();
    console.dir(this.newUser);
  }
  constructor() { 
  }

  ngOnInit() {
  }

}
