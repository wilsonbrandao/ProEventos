import { Evento } from "./Evento";
import { RedeSocial } from "./rede-social";

export interface Palestrante {
  id: number;
  nome: string;
  minicurriculo: number;
  imagemURL: string;
  telefone: string;
  email: string;
  redeSociais: RedeSocial[];
  palestranteEventos: Evento[];
}
