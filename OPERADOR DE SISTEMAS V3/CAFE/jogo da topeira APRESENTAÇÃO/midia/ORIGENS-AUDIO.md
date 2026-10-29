# Áudio da Ilha da Toupeira

- **acerto-stomp.wav:** efeito curto “Stomp” de *Super Mario Bros.* (Nintendo), disponibilizado pelo arquivo [The Mushroom Kingdom](https://themushroomkingdom.net/media/smb/wav). [Arquivo de origem](https://themushroomkingdom.net/sounds/wav/smb/smb_stomp.wav). Convertido para PCM mono, 16 bits, 22.050 Hz.
- **musica-partida.wav:** áudio enviado pelo usuário para acompanhar a partida. Convertido para PCM mono, 16 bits, 22.050 Hz, sem metadados; duração de aproximadamente 191 segundos. O jogo repete a faixa automaticamente e começa com o volume baixo.
- **Música do menu:** `musica-menu.mp3` é a faixa enviada para o Form1, lida localmente e ignorada pelo Git. Se faltar, o menu usa o tema original de `AudioRetro.cs`.
- **Música da partida:** `musica-partida.wav` é a faixa do Form2. O Form1 para sua música ao iniciar a partida; o Form2 toca e pausa sua própria faixa independentemente.
- **Sinais de interface/vitória:** gerados pelo código de `AudioRetro.cs` para este projeto.

Os créditos identificam as origens; não transferem a autoria nem a licença dos áudios de terceiros. A música e os efeitos têm volumes independentes nas opções do jogo.
