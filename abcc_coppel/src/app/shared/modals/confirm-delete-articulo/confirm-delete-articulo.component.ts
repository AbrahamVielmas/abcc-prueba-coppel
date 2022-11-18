import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';

@Component({
  selector: 'app-confirm-delete-articulo',
  templateUrl: './confirm-delete-articulo.component.html',
  styleUrls: ['./confirm-delete-articulo.component.css']
})
export class ConfirmDeleteArticuloComponent implements OnInit {

  constructor(
    public dialogRef: MatDialogRef<ConfirmDeleteArticuloComponent>,
    @Inject(MAT_DIALOG_DATA) public sku: number,
  ) { }

  ngOnInit(): void {
  }

  onNoClick(): void {
    this.dialogRef.close(false);
  }

  onYesClick(): void {
    this.dialogRef.close(true);
  }

}
