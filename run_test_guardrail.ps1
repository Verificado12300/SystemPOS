$exe = 'E:\SistemaPOS\bin\Debug\SistemaPOS.exe'
$log = 'E:\SistemaPOS\bin\Debug\test_guardrail.log'

if (Test-Path $log) { Remove-Item $log }

Start-Process -FilePath $exe -ArgumentList '--test-guardrail' -Wait -WindowStyle Hidden

if (Test-Path $log) {
    Get-Content $log
} else {
    Write-Error "No se generó test_guardrail.log"
}
