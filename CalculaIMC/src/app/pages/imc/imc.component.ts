import { Component, OnInit } from "@angular/core";
import { Usuario } from "src/app/models/usuario";
import { HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";
import { Imc } from "src/app/models/imc";

@Component({
	selector: "app-imc",
	templateUrl: "./imc.component.html",
	styleUrls: ["./imc.component.css"],
})
export class ImcComponent implements OnInit {
	constructor(private http: HttpClient, private router: Router) {}

	id?: number;
	peso?: number;
	altura?: number;
	imcUsuario?: number;
	classificacao?: number;
	usuarioid?: number;
	usuarios?: Usuario[];
	datacriacao?: Date;
	imcs!: Imc[];
	usuarioNome?: string;
	usuarioNascimento?: Date;
	classificacaoFormatada?: string;

	ngOnInit(): void {
		this.http
			.get<Usuario[]>("https://localhost:5001/api/usuarios/listar")
			.subscribe({
				next: (usuarios) => {
					this.usuarios = usuarios;
				},
			});

		this.http.get<Imc[]>("https://localhost:5001/api/imc/listar").subscribe({
			next: (imcs) => {
				this.imcs = imcs;
			},
		});
	}

	cadastrar(): void {
		let imc: Imc = {
			id: this.id,
			peso: this.peso,
			altura: this.altura,
			imcUsuario: this.imcUsuario,
			classificacao: this.classificacao,
			usuarioid: this.usuarioid,
			dataCriacao: new Date(),
			usuarioNome: this.usuarioNome,
			usuarioNascimento: this.usuarioNascimento,
			classificacaoFormatada: this.classificacaoFormatada,
		};

		this.http
			.post<Imc>(
				"https://localhost:5001/api/imc/cadastrar",
				imc
			)
			.subscribe({ next: (imc) => this.imcs.push(imc) });
	}
}
