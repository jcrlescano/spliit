import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { GroupService } from '../../../core/services/group.service';
import { Group } from '../../../core/models/group.model';

@Component({
  selector: 'app-group-form',
  templateUrl: './group-form.component.html',
  styleUrls: ['./group-form.component.scss']
})
export class GroupFormComponent implements OnInit {
  @Input() group?: Group;
  @Output() saved = new EventEmitter<void>();

  form!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private groupService: GroupService
  ) {}

  ngOnInit(): void {
    this.form = this.fb.group({
      name: [this.group?.name || '', Validators.required],
      information: [this.group?.information || ''],
      currency: [this.group?.currency || '$', Validators.required],
      currencyCode: [this.group?.currencyCode || 'USD']
    });
  }

  onSubmit(): void {
    if (this.form.valid) {
      const formValue = this.form.value;
      
      if (this.group) {
        this.groupService.update(this.group.id, formValue).subscribe(() => {
          this.saved.emit();
        });
      } else {
        this.groupService.create(formValue).subscribe(() => {
          this.saved.emit();
        });
      }
    }
  }
}
