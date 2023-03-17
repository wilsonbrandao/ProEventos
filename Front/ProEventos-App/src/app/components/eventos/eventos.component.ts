import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { EventoService } from '../../services/evento.service';
import { Evento } from '../../models/Evento';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss'],
  // providers: [EventoService]
})
export class EventosComponent implements OnInit {

  public modalRef = {} as BsModalRef;
  public eventos: Evento[] = [];
  public eventosFiltrados: Evento[] = [];
  public widthImg: number = 150;
  public marginImg: number = 2;
  public showImg: boolean = true;
  private _filtroLista: string = '';


  // ====================GET / SET =======================

  public get filtroLista(): string {
    return this._filtroLista;
  }

  public set filtroLista(value: string) {
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  // ================== CONSTRUCTOR =========================

  constructor(
    private eventoService: EventoService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService
  ) { }

  public ngOnInit(): void {

    this.spinner.show();
    this.getEventos();

  }

  // =======================EVENTOS TABLE ====================

  public getEventos(): void {

    const observer = {
      next: (resEventos: Evento[]) => {
          this.eventos = resEventos;
          this.eventosFiltrados = this.eventos;
      },
      error: (error: any) => {
        this.spinner.hide();
        this.toastr.error('Erro ao carregar os Eventos', 'Erro!');
      },
      complete: () => {this.spinner.hide(); }
    };

    this.eventoService.getEventos().subscribe(observer);
  }

  public handlerImg(): void{
    this.showImg = !this.showImg;
  }

  public filtrarEventos(filterBy: string) : Evento[] {
    filterBy = filterBy.toLocaleLowerCase();
    return this.eventos
      .filter((event: { tema: string; local: string; }) => {
        return event.tema.toLocaleLowerCase().indexOf(filterBy) !== -1
          || event.local.toLocaleLowerCase().indexOf(filterBy) !== -1
    });
  }

  // ==================== MODAL =======================

  public openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  public confirm(): void {
    this.modalRef.hide();
    this.toastr.success('O evento foi deletado', 'Deletado!');
  }

  public decline(): void {
    this.modalRef.hide();
  }

  // ====================  =======================
}
