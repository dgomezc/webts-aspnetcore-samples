const fs = require("fs");
const fse = require("fs-extra");
const childProcess = require("child_process");

if (fs.existsSync("./build")) {
  fse.removeSync("./build");
}

fse.emptyDirSync('./publish');

childProcess.execSync("dotnet clean ./server /p:GenerateFullPaths=true /consoleloggerparameters:NoSummary", { stdio: "inherit" });
childProcess.execSync("dotnet publish ./server -c Release -o ./publish /p:GenerateFullPaths=true /consoleloggerparameters:NoSummary", { stdio: "inherit" });

childProcess.execSync("react-scripts build", { stdio: "inherit" });
fse.moveSync("./build", "./publish/ClientApp/build", { overwrite: true });