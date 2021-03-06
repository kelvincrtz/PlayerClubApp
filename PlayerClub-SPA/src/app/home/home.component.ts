import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  registerPlayerMode = false;
  registerTeamMode = false;

  constructor() { }

  ngOnInit() {
  }

  registerPlayerToggle() {
    this.registerPlayerMode = true;
  }

  registerTeamToggle() {
    this.registerTeamMode = true;
  }

  cancelRegisterPlayerMode(registerPlayerMode: boolean) {
    this.registerPlayerMode = registerPlayerMode;
  }

  cancelRegisterTeamMode(registerTeamMode: boolean) {
    this.registerTeamMode = registerTeamMode;
  }

}
