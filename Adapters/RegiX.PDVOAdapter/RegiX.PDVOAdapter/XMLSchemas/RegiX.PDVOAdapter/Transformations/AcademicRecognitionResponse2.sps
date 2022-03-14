<?xml version="1.0" encoding="UTF-8"?>
<structure version="20" xsltversion="1" html-doctype="HTML4 Transitional" compatibility-view="IE9" html-outputextent="Complete" relativeto="*SPS" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8" useimportschema="1" embed-images="1" enable-authentic-scripts="1" authentic-scripts-in-debug-mode-external="0" generated-file-location="DEFAULT">
	<parameters/>
	<schemasources>
		<namespaces>
			<nspair prefix="n1" uri="http://egov.bg/RegiX/NACID/PDVO/AcademicRecognitionResponse"/>
		</namespaces>
		<schemasources>
			<xsdschemasource name="XML" main="1" schemafile="D:\Projects\eGov\RegiX\RegiX.PDVOAdapter\XMLSchemas\AcademicRecognitionResponse.xsd" workingxmlfile="AcademicRecognitionResponse1.xml"/>
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
		<Project version="4" app="AuthenticView"/>
	</script-project>
	<importedxslt/>
	<globalstyles/>
	<mainparts>
		<children>
			<globaltemplate subtype="main" match="/">
				<document-properties/>
				<styles border-style="dashed" height="11.69in" max-height="11.69in" max-width="8.27in" min-height="11.69in" min-width="8.27in" width="8.27in"/>
				<children>
					<documentsection>
						<properties columncount="1" columngap="0.50in" ends-on-page="odd" headerfooterheight="fixed" pagemultiplepages="0" pagenumberingformat="1" pagenumberingstartat="auto" pagestart="next" paperheight="11.69in" papermarginbottom="0.79in" papermarginfooter="0.30in" papermarginheader="0.30in" papermarginleft="0.60in" papermarginright="0.60in" papermargintop="0.79in" paperwidth="8.27in"/>
						<watermark>
							<image transparency="50" fill-page="1" center-if-not-fill="1"/>
							<text transparency="50"/>
						</watermark>
					</documentsection>
					<template subtype="source" match="XML">
						<children>
							<template subtype="element" match="n1:AcademicRecognitionResponse">
								<children>
									<newline/>
									<newline/>
									<paragraph paragraphtag="center">
										<children>
											<paragraph>
												<styles text-align="center" width="3.7IN"/>
												<children>
													<text fixtext="РЕПУБЛИКА БЪЛГАРИЯ">
														<styles font-family="Times New Roman" font-size="16px" font-weight="bold" letter-spacing="2PX"/>
													</text>
													<line>
														<styles font-size="1px"/>
													</line>
													<text fixtext="МИНИСТЕРСТВО НА ОБРАЗОВАНИЕТО И НАУКАТА">
														<styles font-family="Times New Roman" font-size="16px" letter-spacing="1PX"/>
													</text>
												</children>
											</paragraph>
										</children>
									</paragraph>
									<newline/>
									<newline/>
									<newline/>
									<paragraph paragraphtag="center">
										<children>
											<text fixtext="УДОСТОВЕРЕНИЕ">
												<styles font-family="Times New Roman" font-size="32PX" font-weight="bold" letter-spacing="2PX"/>
											</text>
										</children>
									</paragraph>
									<newline/>
									<paragraph paragraphtag="center">
										<children>
											<text fixtext="№ "/>
											<template subtype="element" match="n1:CertificateNums">
												<children>
													<template subtype="element" match="n1:CertificateNum">
														<children>
															<content subtype="regular"/>
														</children>
														<variables/>
													</template>
												</children>
												<variables/>
											</template>
										</children>
									</paragraph>
									<newline/>
									<paragraph>
										<children>
											<text fixtext="На основание чл. 10, ал. 2, т. 4 от Закона за висшето образование се признава висше образование на "/>
										</children>
									</paragraph>
									<paragraph paragraphtag="center">
										<children>
											<paragraph>
												<styles text-align="center" width="4in"/>
												<children>
													<template subtype="element" match="n1:FirstName">
														<children>
															<content subtype="regular"/>
														</children>
														<variables/>
													</template>
													<template subtype="element" match="n1:MiddleName">
														<children>
															<text fixtext=" "/>
															<content subtype="regular"/>
														</children>
														<variables/>
													</template>
													<template subtype="element" match="n1:LastName">
														<children>
															<text fixtext=" "/>
															<content subtype="regular"/>
														</children>
														<variables/>
													</template>
													<line>
														<styles border-style="dashed" font-size="1px"/>
													</line>
												</children>
											</paragraph>
										</children>
									</paragraph>
									<newline/>
								</children>
								<variables/>
							</template>
							<paragraph paragraphtag="p">
								<children>
									<template subtype="element" match="n1:AcademicRecognitionResponse">
										<children>
											<text fixtext="Деловоден номер: "/>
											<template subtype="element" match="n1:InternalAppNum">
												<children>
													<content subtype="regular"/>
												</children>
												<variables/>
											</template>
											<newline/>
											<text fixtext="Дата:"/>
											<template subtype="element" match="n1:InternalAppDate">
												<children>
													<content subtype="regular">
														<format basic-type="xsd" string="DD.MM.YYYY" datatype="date"/>
													</content>
												</children>
												<variables/>
											</template>
											<newline/>
											<text fixtext="Статус: "/>
											<template subtype="element" match="n1:AcademicRecognitionStatus">
												<children>
													<content subtype="regular"/>
												</children>
												<variables/>
											</template>
											<template subtype="element" match="n1:RecognitionRefusal">
												<children>
													<newline/>
													<text fixtext="Мотиви за непризнаване: "/>
													<content subtype="regular"/>
												</children>
												<variables/>
											</template>
											<template subtype="element" match="n1:CertificateNums">
												<children>
													<newline/>
													<text fixtext="Удостоверения: "/>
													<template subtype="element" match="n1:CertificateNum">
														<children>
															<content subtype="regular"/>
															<condition>
																<children>
																	<conditionbranch xpath="count(following::n1:CertificateNum)&gt;0">
																		<children>
																			<text fixtext=", "/>
																		</children>
																	</conditionbranch>
																</children>
															</condition>
														</children>
														<variables/>
													</template>
												</children>
												<variables/>
											</template>
											<template subtype="element" match="n1:FirstName">
												<children>
													<newline/>
													<text fixtext="Име: "/>
													<content subtype="regular"/>
												</children>
												<variables/>
											</template>
											<template subtype="element" match="n1:MiddleName">
												<children>
													<text fixtext=" "/>
													<content subtype="regular"/>
												</children>
												<variables/>
											</template>
											<template subtype="element" match="n1:LastName">
												<children>
													<text fixtext=" "/>
													<content subtype="regular"/>
												</children>
												<variables/>
											</template>
											<newline/>
											<template subtype="element" match="n1:IdentificatorTypeName">
												<children>
													<content subtype="regular"/>
													<text fixtext=": "/>
												</children>
												<variables/>
											</template>
											<template subtype="element" match="n1:Identificator">
												<children>
													<content subtype="regular"/>
												</children>
												<variables/>
											</template>
											<text fixtext=" "/>
											<template subtype="element" match="n1:RecognizedEduLevel">
												<children>
													<newline/>
													<text fixtext="Призната образователно-квалификационна степен: "/>
													<content subtype="regular"/>
												</children>
												<variables/>
											</template>
											<template subtype="element" match="n1:RecognizedSpecialities">
												<children>
													<newline/>
													<text fixtext="Признати специалности: "/>
													<template subtype="element" match="n1:RecognizedSpecialityName">
														<children>
															<content subtype="regular"/>
															<condition>
																<children>
																	<conditionbranch xpath="count(following::n1:RecognizedSpecialityName)&gt;0">
																		<children>
																			<text fixtext=", "/>
																		</children>
																	</conditionbranch>
																</children>
															</condition>
														</children>
														<variables/>
													</template>
												</children>
												<variables/>
											</template>
											<template subtype="element" match="n1:RecognizedProfQualName">
												<children>
													<newline/>
													<text fixtext="Професионална квалификация: "/>
													<content subtype="regular"/>
												</children>
												<variables/>
											</template>
											<newline/>
											<condition>
												<children>
													<conditionbranch xpath="string-length( n1:UniversityOriginalName )&gt;0 or string-length( n1:UniversityNameCyrillic ) &gt;0 or string-length( n1:CountryNameCyrillic ) &gt;0 or string-length( n1:SettlementAbroadName ) &gt;0 or string-length( n1:AddressDescriptionAbroad ) &gt; 0">
														<children>
															<text fixtext="Висше училище в чужбина: "/>
														</children>
													</conditionbranch>
												</children>
											</condition>
											<template subtype="element" match="n1:UniversityOriginalName">
												<children>
													<content subtype="regular"/>
													<text fixtext=", "/>
												</children>
												<variables/>
											</template>
											<template subtype="element" match="n1:UniversityNameCyrillic">
												<children>
													<content subtype="regular"/>
													<text fixtext=", "/>
												</children>
												<variables/>
											</template>
											<template subtype="element" match="n1:CountryNameCyrillic">
												<children>
													<content subtype="regular"/>
													<text fixtext=", "/>
												</children>
												<variables/>
											</template>
											<template subtype="element" match="n1:SettlementAbroadName">
												<children>
													<content subtype="regular"/>
													<text fixtext=", "/>
												</children>
												<variables/>
											</template>
											<text fixtext=" "/>
											<template subtype="element" match="n1:AddressDescriptionAbroad">
												<children>
													<content subtype="regular"/>
												</children>
												<variables/>
											</template>
										</children>
										<variables/>
									</template>
								</children>
							</paragraph>
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
