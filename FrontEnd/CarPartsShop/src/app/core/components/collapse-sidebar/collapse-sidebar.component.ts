import { Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { NgbCollapseModule } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-collapse-sidebar',
  standalone: true,
  templateUrl: './collapse-sidebar.component.html',
  imports: [NgbCollapseModule, RouterLink],
})
export class CollapseSidebarComponent {
  isMenuCollapsed: boolean = true;
}
