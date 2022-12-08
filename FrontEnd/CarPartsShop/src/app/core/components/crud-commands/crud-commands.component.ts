import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'crud-commands',
  templateUrl: './crud-commands.component.html',
})
export class CrudCommandsComponent {
  @Input()
  public showAdd: boolean = true;
}
