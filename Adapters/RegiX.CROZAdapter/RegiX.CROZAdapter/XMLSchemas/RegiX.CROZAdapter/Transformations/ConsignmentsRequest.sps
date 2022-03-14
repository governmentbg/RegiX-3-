<?xml version="1.0" encoding="UTF-8"?>
<structure version="16" xsltversion="1" html-doctype="HTML4 Transitional" compatibility-view="IE9" relativeto="*SPS" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8" useimportschema="1" embed-images="1" enable-authentic-scripts="1" authentic-scripts-in-debug-mode-external="0" generated-file-location="DEFAULT">
	<parameters/>
	<schemasources>
		<namespaces>
			<nspair prefix="n1" uri="http://egov.bg/RegiX/CROZ/CROZ/ConsignmentsRequest"/>
		</namespaces>
		<schemasources>
			<xsdschemasource name="XML" main="1" schemafile="xsd_current\ConsignmentsRequest.xsd" workingxmlfile="ConsignmentsRequest.xml"/>
		</schemasources>
	</schemasources>
	<modules/>
	<flags>
		<scripts/>
		<mainparts/>
		<globalparts/>
		<designfragments/>
		<pagelayouts/>
		<xpath-functions/>
	</flags>
	<scripts>
		<script language="javascript"/>
	</scripts>
	<script-project>
		<Project version="2" app="AuthenticView"/>
	</script-project>
	<importedxslt/>
	<globalstyles/>
	<mainparts>
		<children>
			<globaltemplate subtype="main" match="/">
				<document-properties/>
				<children>
					<documentsection>
						<properties columncount="1" columngap="0.50in" headerfooterheight="fixed" pagemultiplepages="0" pagenumberingformat="1" pagenumberingstartat="auto" pagestart="next" paperheight="11in" papermarginbottom="0.79in" papermarginfooter="0.30in" papermarginheader="0.30in" papermarginleft="0.60in" papermarginright="0.60in" papermargintop="0.79in" paperwidth="8.50in"/>
						<watermark>
							<image transparency="50" fill-page="1" center-if-not-fill="1"/>
							<text transparency="50"/>
						</watermark>
					</documentsection>
					<template subtype="source" match="XML">
						<children>
							<template subtype="element" match="n1:ConsignmentsRequest">
								<children>
									<paragraph paragraphtag="h3">
										<styles font-size="18px" text-align="center"/>
										<children>
											<text fixtext="Заявка за справка за вписванията по партида в Централния регистър на особените залози"/>
										</children>
									</paragraph>
									<newline/>
									<template subtype="element" match="n1:ParticipantID">
										<children>
											<text fixtext="Служебен идентификатор на участник: ">
												<styles font-size="16px"/>
											</text>
											<content subtype="regular">
												<styles font-size="16px" font-weight="bold"/>
												<format basic-type="xsd" datatype="int"/>
											</content>
										</children>
										<variables/>
									</template>
									<template subtype="element" match="n1:DateFrom">
										<children>
											<newline/>
											<text fixtext="От дата: ">
												<styles font-size="16px"/>
											</text>
											<content subtype="regular">
												<styles font-size="16px" font-weight="bold"/>
												<format basic-type="xsd" string="DD.MM.YYYY" datatype="date"/>
											</content>
										</children>
										<variables/>
									</template>
									<template subtype="element" match="n1:DateTo">
										<children>
											<newline/>
											<text fixtext="До дата: ">
												<styles font-size="16px"/>
											</text>
											<content subtype="regular">
												<styles font-size="16px" font-weight="bold"/>
												<format basic-type="xsd" string="DD.MM.YYYY" datatype="date"/>
											</content>
										</children>
										<variables/>
									</template>
								</children>
								<variables/>
							</template>
						</children>
						<variables/>
					</template>
				</children>
			</globaltemplate>
		</children>
	</mainparts>
	<globalparts/>
	<designfragments/>
	<xmltables/>
	<authentic-custom-toolbar-buttons/>
</structure>
