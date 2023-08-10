import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Pessoa } from 'src/app/Models/Pessoa';
import { PessoaService } from 'src/app/services/pessoa.service';
import { DialogService } from 'src/app/share/dialog.service';

@Component({
  selector: 'app-pessoa',
  templateUrl: './pessoa.component.html',
  styleUrls: ['./pessoa.component.css']
})
export class PessoaComponent implements OnInit {

  ngOnInit(): void {
    this.carregarPessoas();
  }


  constructor(private pessoaService: PessoaService,
    private fb: FormBuilder,
    private dialogService: DialogService) {
    this.CreateFormPessoa();
  }

  public frmPessoa!: FormGroup;
  public p_submitted!: boolean;
  public p_titulo_pessoa = 'Cadastro de Pessoas';
  public oPessoas: Pessoa[] = [];
  public oPessoa!: Pessoa;
  public pessoaSelecionada!: Pessoa;
  public modo: string = '';
  public newPessoa: Pessoa = new Pessoa;
  // public listGerentes?: Pessoa[];
  // ------------------------------------------

  CreateFormPessoa() {
    this.frmPessoa = this.fb.group({
      pessoaId: [''],
      nome: ['', [Validators.required, Validators.minLength(10)]],
      cpf: ['', [Validators.maxLength(11)]],
      dataNascimento: [''],
      isFuncionario: [''],
      projetoId: ['']
    })
  }

  EnviaPessoa() {
    this.p_submitted = true;

    if (this.frmPessoa.invalid) {
      return
    }
    (this.pessoaSelecionada?.pessoaId != 0) ? this.modo = 'put' : this.modo = 'post';

    if (this.modo == 'put') {

      if (typeof this.frmPessoa.value.pessoaId === "undefined") {
        this.frmPessoa.value.pessoaId = this.pessoaSelecionada.pessoaId;
      }

      this.atualizaPessoa(this.frmPessoa.value);
      this.Voltar();
    }

    if (this.modo == 'post') {
      this.newPessoa = this.frmPessoa.value;
      this.CreateNewPessoaPrepare(this.frmPessoa.value);
      this.Voltar();
    }

    this.ResetForm();

  }

  pessoaNova() {
    this.ResetForm();
    this.pessoaSelecionada = new Pessoa();
    this.frmPessoa.patchValue(this.pessoaSelecionada);
  }


  atualizaPessoa(pessoaUpd: Pessoa) {
    this.pessoaService.UpdatePessoa(pessoaUpd).subscribe({
      next: (pessoa: Pessoa) => {
        console.log(pessoa)
        this.carregarPessoas();
      },
      error: (err) => {
        console.log(err);
      }
    })
  }

  Voltar() {
    this.pessoaSelecionada = this.oPessoa;
  }

  CreateNewPessoaPrepare(pessoa: Pessoa) {
    this.pessoaService.CreateNewPessoa(pessoa).subscribe({
      next: (newCustomer = pessoa) => {
        this.carregarPessoas();
      },
      error: (err) => {
        console.log('Found errors: ' + err);
      }
    })
  }

  carregarPessoas(): void {
    this.pessoaService.GetAllPessoas().subscribe({
      next: (pessoas: Pessoa[]) => {
        this.oPessoas = pessoas;
        console.log(pessoas);
      },
      error: (err) => {
        console.log('somethings wrong occurred: ' + err);
      }
    });
  }

  pessoaSelected(pessoa: Pessoa) {
    this.pessoaSelecionada = pessoa;
    this.frmPessoa.patchValue(pessoa);
  }

  pessoaExcluir(pessoaForm: Pessoa) {
    this.dialogService.confirmDialog({
      title: 'EXCLUSÃO DE DADOS',
      message: `Confirma a exclusão da Pessoa: ${pessoaForm.nome} ?`,
      confirmText: 'Sim',
      cancelText: 'Não',
    },).subscribe(res => {
      if (res) {
        this.pessoaService.RemovePessoa(pessoaForm.pessoaId).subscribe({
          next: () => {
            // this.toastr.info('Registro excluído com sucesso !', 'EXCLUSÃO DE DADOS');
            this.carregarPessoas();
          },
          error: (err) => {
            console.log(err);
          }
        })
      }

    })
  }//end method

  LimpaPessoaForms() {
    this.frmPessoa.reset(new Pessoa());
  }

  ResetForm(): void {
    this.frmPessoa.reset();
  }


}
