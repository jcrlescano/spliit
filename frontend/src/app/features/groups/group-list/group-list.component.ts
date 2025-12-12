import { Component, OnInit } from '@angular/core';
import { GroupService } from '../../../core/services/group.service';
import { Group } from '../../../core/models/group.model';

@Component({
  selector: 'app-group-list',
  templateUrl: './group-list.component.html',
  styleUrls: ['./group-list.component.scss']
})
export class GroupListComponent implements OnInit {
  groups: Group[] = [];
  displayDialog = false;
  selectedGroup?: Group;

  constructor(private groupService: GroupService) {}

  ngOnInit(): void {
    this.loadGroups();
  }

  loadGroups(): void {
    this.groupService.getAll().subscribe(groups => {
      this.groups = groups;
    });
  }

  showCreateDialog(): void {
    this.selectedGroup = undefined;
    this.displayDialog = true;
  }

  showEditDialog(group: Group): void {
    this.selectedGroup = group;
    this.displayDialog = true;
  }

  onGroupSaved(): void {
    this.displayDialog = false;
    this.loadGroups();
  }

  deleteGroup(id: string): void {
    if (confirm('Are you sure you want to delete this group?')) {
      this.groupService.delete(id).subscribe(() => {
        this.loadGroups();
      });
    }
  }
}
