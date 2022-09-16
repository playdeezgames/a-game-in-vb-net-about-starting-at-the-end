dotnet publish ./src/AGameInVbNetAboutStartingAtTheEnd/AGameInVbNetAboutStartingAtTheEnd.vbproj -o ./pub-linux -c Release --sc -r linux-x64
dotnet publish ./src/AGameInVbNetAboutStartingAtTheEnd/AGameInVbNetAboutStartingAtTheEnd.vbproj -o ./pub-windows -c Release --sc -r win-x64
butler push pub-windows thegrumpygamedev/a-game-in-vbnet-about-starting-at-the-end:windows
butler push pub-linux thegrumpygamedev/a-game-in-vbnet-about-starting-at-the-end:linux
git add -A
git commit -m "shipped it!"