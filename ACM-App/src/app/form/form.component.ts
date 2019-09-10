import { Component, OnInit } from '@angular/core';
import { User } from '../user';


@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit {
  
  counter = 0;
  newUser = new User(1,'a','b','c','d','e','f','g','h','i','j','k','l',false,2,3,'m','n','o','p','q',false,4,'r',5);

  year:string[] = ["Freshman","Sophomore","Junior","Senior","Grad Masters","Grad PHD","Professor","Alumni","Other"];
  commute:string[]=["Live on Campus", "Walking Distance", ">30 min", ">1 hour","Other"];
  interest:string[]=["Security","Visualization","Computer Human Interaction","Machine Learning","Education","Mathematics","Scalable Computing"];
  sigs:string[]=["SysAdmin","BlockChain","Algorithmic Trading","Math","Windows","None of the above"];
  majorEvents:string[]=["Flourish!(An open source conference run by LUG and ACM student Orgs)",
                       "Hackathon",
                       "IT D3bug Challenges",
                       "Programming Challenges",
                       "Reflection Projection",
                       "Not interested"
                      ];
  competition:string[]=["Hack Illinois",
                      "ICPC programming competition",
                      "Google Tech Challenge",
                      "Loyola Datafest",
                      "DOE Cyberforce Competition"
                      ];
  nextCounter(){
    this.counter++;
  }
  backCounter(){
    this.counter--;
  }
  onSubmit(){
    console.dir(this.newUser);
  }
  constructor() { 
  }

  ngOnInit() {
  }

}
