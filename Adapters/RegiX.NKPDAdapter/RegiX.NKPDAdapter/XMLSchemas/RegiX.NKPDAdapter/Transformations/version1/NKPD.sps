<?xml version="1.0" encoding="UTF-8"?>
<structure version="16" html-doctype="HTML4 Transitional" compatibility-view="IE9" relativeto="*SPS" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8" useimportschema="1" embed-images="1" enable-authentic-scripts="1" authentic-scripts-in-debug-mode-external="0" generated-file-location="DEFAULT">
	<parameters/>
	<schemasources>
		<namespaces>
			<nspair prefix="ncoocc" uri="http://ereg.egov.bg/value/R-1045"/>
			<nspair prefix="ncooeaqlc" uri="http://ereg.egov.bg/value/R-1061"/>
			<nspair prefix="ncoogc" uri="http://ereg.egov.bg/value/R-1053"/>
			<nspair prefix="ncooigc" uri="http://ereg.egov.bg/value/R-1057"/>
			<nspair prefix="ncoopc" uri="http://ereg.egov.bg/value/R-1065"/>
			<nspair prefix="ncoopn" uri="http://ereg.egov.bg/value/R-1067"/>
			<nspair prefix="ncoosc" uri="http://ereg.egov.bg/value/R-1049"/>
		</namespaces>
		<schemasources>
			<xsdschemasource name="XML" main="1" schemafile="NKPDDataSchema.xsd" workingxmlfile="nkpd8.xml"/>
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
					<newline/>
					<paragraph paragraphtag="center">
						<children>
							<template subtype="source" match="XML">
								<children>
									<template subtype="element" match="NKPDs">
										<children>
											<template subtype="element" match="VersionName">
												<children>
													<content subtype="regular">
														<styles font-size="14pt" font-weight="bold"/>
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
					</paragraph>
					<newline/>
					<newline/>
					<tgrid>
						<properties border="1"/>
						<styles border-collapse="collapse"/>
						<children>
							<tgridbody-cols>
								<children>
									<tgridcol/>
									<tgridcol/>
									<tgridcol/>
								</children>
							</tgridbody-cols>
							<tgridheader-rows>
								<children>
									<tgridrow>
										<children>
											<tgridcell>
												<children>
													<text fixtext="Код"/>
												</children>
											</tgridcell>
											<tgridcell joinleft="1"/>
											<tgridcell>
												<children>
													<text fixtext="Наименование"/>
												</children>
											</tgridcell>
										</children>
									</tgridrow>
								</children>
							</tgridheader-rows>
							<tgridbody-rows>
								<children>
									<template subtype="source" match="XML">
										<children>
											<template subtype="element" match="NKPDs">
												<children>
													<template subtype="element" match="NKPD">
														<sort>
															<key match="if (substring( ClassCode,  0 ,  2 )  = &quot;0&quot;) then &quot;91&quot; else ClassCode"/>
															<key match="SubclassCode"/>
															<key match="GroupCode"/>
															<key match="IndividualGroupCode"/>
															<key match="substring( Code ,  6, 4)"/>
														</sort>
														<children>
															<tgridrow>
																<children>
																	<tgridcell>
																		<children>
																			<condition displayallbranches="1">
																				<children>
																					<conditionbranch xpath="Type = &quot;nkpd&quot;">
																						<children>
																							<template subtype="userdefined" match="substring( Code ,  0 ,  5 )">
																								<children>
																									<content subtype="regular"/>
																								</children>
																								<variables/>
																							</template>
																						</children>
																					</conditionbranch>
																					<conditionbranch>
																						<children>
																							<template subtype="element" match="Code">
																								<children>
																									<content subtype="regular">
																										<styles font-weight="bold"/>
																									</content>
																								</children>
																								<variables/>
																							</template>
																						</children>
																					</conditionbranch>
																				</children>
																			</condition>
																		</children>
																	</tgridcell>
																	<tgridcell>
																		<children>
																			<condition displayallbranches="1">
																				<children>
																					<conditionbranch xpath="Type = &apos;nkpd&apos;">
																						<children>
																							<template subtype="userdefined" match="substring( Code ,  5 )">
																								<children>
																									<content subtype="regular"/>
																								</children>
																								<variables/>
																							</template>
																						</children>
																					</conditionbranch>
																					<conditionbranch/>
																				</children>
																			</condition>
																		</children>
																	</tgridcell>
																	<tgridcell>
																		<children>
																			<condition>
																				<children>
																					<conditionbranch xpath="Type = &quot;nkpd&quot;">
																						<children>
																							<template subtype="element" match="Name">
																								<children>
																									<content subtype="regular"/>
																								</children>
																								<variables/>
																							</template>
																						</children>
																					</conditionbranch>
																					<conditionbranch>
																						<children>
																							<template subtype="element" match="Name">
																								<children>
																									<content subtype="regular">
																										<styles font-weight="bold"/>
																									</content>
																								</children>
																								<variables/>
																							</template>
																						</children>
																					</conditionbranch>
																				</children>
																			</condition>
																		</children>
																	</tgridcell>
																</children>
															</tgridrow>
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
							</tgridbody-rows>
						</children>
					</tgrid>
				</children>
			</globaltemplate>
		</children>
	</mainparts>
	<globalparts/>
	<designfragments/>
	<xmltables/>
	<authentic-custom-toolbar-buttons/>
</structure>
