import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Team } from '../_models/team';
import { TeamService } from '../_services/team.service';

@Component({
  selector: 'app-register-team',
  templateUrl: './register-team.component.html',
  styleUrls: ['./register-team.component.css']
})
export class RegisterTeamComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
  team: Team;
  registerForm: FormGroup;

  constructor(private teamService: TeamService, private fb: FormBuilder, private router: Router) { }

  ngOnInit() {
    this.createRegisterForm();
  }

  createRegisterForm() {
    this.registerForm = this.fb.group({
      name: ['', Validators.required],
      ground: ['', Validators.required],
      coach: ['', Validators.required],
      foundedYear: [null, Validators.required],
      region: ['', Validators.required]
    });
  }

  register() {
    if (this.registerForm.valid) {
      this.team = Object.assign({}, this.registerForm.value);
      this.teamService.register(this.team).subscribe(() => {
        console.log('Registration successful');
      }, error => {
        console.log(error);
      }, () => {
        this.router.navigate(['/teams/']);
      });
    }
  }

  cancel() {
    this.cancelRegister.emit(false);
    console.log('Cancelled');
  }
}
