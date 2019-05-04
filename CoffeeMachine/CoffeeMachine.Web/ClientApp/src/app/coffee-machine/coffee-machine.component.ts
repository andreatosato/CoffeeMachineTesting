import { Component, OnInit } from '@angular/core';
import { MachineService } from '../machine.service';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-coffee-machine',
  templateUrl: './coffee-machine.component.html',
  styleUrls: ['./coffee-machine.component.css']
})
export class CoffeeMachineComponent implements OnInit {
  machineForm: FormGroup;
  drinkTypes: DrinkType[];

  constructor(private fb: FormBuilder, private machineService: MachineService) { }

  ngOnInit() {
    // Test
    this.drinkTypes = [
      { "Name": "caffe", "Price" : 1 },
      { "Name": "cappuccino", "Price": 1.4 },
      { "Name": "te", "Price": 0.8}
    ];

    this.machineForm = this.fb.group({
      selectedDrink: ['', Validators.required],
      drinkPrice: [0],
      coinInserted: [0, Validators.required],
      coinDifference: [0]
    });
  }

  selectDrinkType(value) {
    const drinkPrice = value.Price;
    const coinInserted = this.machineForm['coinInserted'] !== undefined ? this.machineForm['coinInserted'].value : 0 ;
    const coinDifference = Math.round((coinInserted - drinkPrice) * 100) / 100;
    this.machineForm.controls['selectedDrink'].setValue(value.Name);
    this.machineForm.controls['drinkPrice'].setValue(value.Price);
    this.machineForm.controls['coinDifference'].setValue(coinDifference);
  }

  coinInsert(event) {
    console.log(event.target.value);
    const drinkPrice = this.machineForm.controls['drinkPrice'].value;
    const coinInserted = event.target.value;
    const coinDifference = Math.round((coinInserted - drinkPrice) * 100) / 100;
    this.machineForm.controls['coinDifference'].setValue(coinDifference);
  }

  isValid(): boolean {
    return !this.machineForm.valid || this.machineForm.controls['coinDifference'].value < 0;
  }

  onSubmit() {

  }
}

export class DrinkType {
  Name: string;
  Price: number;
}
