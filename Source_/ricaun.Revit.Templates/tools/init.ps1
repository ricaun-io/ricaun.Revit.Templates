param($installPath, $toolsPath, $package, $project)

	$outputFolder = "ricaun.Revit.Templates"
	$vsVersions = @("2022", "18")
	$location = Get-Location
	
	if (!$toolsPath)
	{
		$toolsPath = Get-Location
		Write-Host "Update ToolsPath $toolsPath"
	}

	Write-Host "Installing $outputFolder Snippets and Templates..."
  
	function InstallFiles ($destination, $files) 
	{
		# Delete destination folder
		if (Test-Path $destination)
		{
			Remove-Item -Recurse -Force $destination
		}

		# Create destination folder
		if ((Test-Path $destination) -ne $true)
		{
			$new = New-Item $destination -ItemType directory
		}

		# Copy files
		if (Test-Path $files)
		{
			Copy-Item $files -Destination $destination -Recurse
			Write-Host " - installing to $destination for Visual Studio $vsVersion."
		}
	}
	
	$sourceSnippetsCS = "$toolsPath\Templates\Snippets\*"
	$sourceTemplatesCS = "$toolsPath\Templates\ItemTemplates\*"
	$sourceProjectTemplatesCS = "$toolsPath\Templates\ProjectTemplates\*"

	$destinationDocumentsRoot = [System.Environment]::GetFolderPath( "MyDocuments" );

  	# Install for all versions of VS defined
	foreach ($vsVersion in $vsVersions) 
	{
		# VS Version test - Test if User's Visual Studio destination path exists and skip if it doesn't
		$destinationUserVisualStudio = Join-Path $destinationDocumentsRoot "\Visual Studio $vsVersion"
		if ((Test-Path $destinationUserVisualStudio) -ne $true) { continue }
		
		$destinationSnippetsFolderCS = Join-Path $destinationUserVisualStudio "\Code Snippets\Visual C#\My Code Snippets\$outputFolder"
		$destinationItemsFolderCS = Join-Path $destinationUserVisualStudio "\Templates\ItemTemplates\Visual C#\$outputFolder"
		$destinationProjectTemplatesFolderCS = Join-Path $destinationUserVisualStudio "\Templates\ProjectTemplates\Visual C#\$outputFolder"

		InstallFiles $destinationSnippetsFolderCS $sourceSnippetsCS
		InstallFiles $destinationItemsFolderCS $sourceTemplatesCS
		InstallFiles $destinationProjectTemplatesFolderCS $sourceProjectTemplatesCS
	}
