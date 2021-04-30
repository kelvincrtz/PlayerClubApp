import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Player } from '../_models/player';
import { PlayerService } from '../_services/player.service';

@Component({
  selector: 'app-register-player',
  templateUrl: './register-player.component.html',
  styleUrls: ['./register-player.component.css']
})
export class RegisterPlayerComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
  player: Player;
  registerForm: FormGroup;

  constructor(private playerService: PlayerService, private fb: FormBuilder) { }

  ngOnInit() {
    this.createRegisterForm();
  }

  createRegisterForm() {
    this.registerForm = this.fb.group({
      name: ['', Validators.required],
      birthdate: [null, Validators.required],
      height: ['', Validators.required],
      weight: ['', Validators.required],
      placeofbirth: ['', Validators.required]
    });
  }

  register() {
    if (this.registerForm.valid) {
      this.player = Object.assign({}, this.registerForm.value);
      this.playerService.register(this.player).subscribe(() => {
        console.log('Registration successful');
      }, error => {
        console.log(error);
      });
    }
  }

  cancel() {
    this.cancelRegister.emit(false);
    console.log('Cancelled');
  }

}
