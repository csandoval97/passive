import { Component, OnInit } from '@angular/core';
import { User } from '../user';


@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit {
  counter = 0;
  newUser = new User(0,'a','b','c','d','e','f','g','h','i','j','k','l',false,0,0,'m','n','o','p','q',false,10,'r',0);
  year:string[] = ["Freshman","Sophomore","Junior","Senior","Grad Masters","Grad PHD","Professor","Alumni","Other"]
  nextCounter(){
    this.counter++;
  }
  backCounter(){
    this.counter--;
  }
  constructor() { 
  }

  ngOnInit() {
  }

}
