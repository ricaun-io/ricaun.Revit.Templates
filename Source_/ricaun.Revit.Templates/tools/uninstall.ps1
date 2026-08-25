param($installPath, $toolsPath, $package, $project)

	$outputFolder = "ricaun.Revit.Templates"
	$vsVersions = @("2022", "18")

	$destinationDocumentsRoot = [System.Environment]::GetFolderPath( "MyDocuments" );

	# Uninstall for all versions of VS defined
	foreach ($vsVersion in $vsVersions)
	{
		# VS Version test - Test if User's Visual Studio destination path exists and skip if it doesn't
		$destinationUserVisualStudio = Join-Path $destinationDocumentsRoot "\Visual Studio $vsVersion"
		if ((Test-Path $destinationUserVisualStudio) -ne $true) { continue }
		
		$destinationSnippetsFolderCS = Join-Path $destinationUserVisualStudio "\Code Snippets\Visual C#\My Code Snippets\$outputFolder"
		$destinationItemsFolderCS = Join-Path $destinationUserVisualStudio "\Templates\ItemTemplates\Visual C#\$outputFolder"
		$destinationProjectTemplatesFolderCS = Join-Path $destinationUserVisualStudio "\Templates\ProjectTemplates\Visual C#\$outputFolder"

		Write-Host "Uninstalling templates and snippets for $outputFolder from Visual Studio $vsVersion"
		if (Test-Path $destinationSnippetsFolderCS)
		{
			Remove-Item -Recurse -Force $destinationSnippetsFolderCS
			Write-Host " - Remove $destinationSnippetsFolderCS"
		}
		if (Test-Path $destinationItemsFolderCS)
		{
			Remove-Item -Recurse -Force $destinationItemsFolderCS
			Write-Host " - Remove $destinationItemsFolderCS"
		}
		if (Test-Path $destinationProjectTemplatesFolderCS)
		{
			Remove-Item -Recurse -Force $destinationProjectTemplatesFolderCS
			Write-Host " - Remove $destinationProjectTemplatesFolderCS"
		}
	}
