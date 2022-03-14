<?xml version="1.0" encoding="UTF-8"?>
<structure version="16" xsltversion="1" html-doctype="HTML4 Transitional" compatibility-view="IE9" relativeto="*SPS" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8" useimportschema="1" embed-images="1" enable-authentic-scripts="1" authentic-scripts-in-debug-mode-external="0" generated-file-location="DEFAULT">
	<parameters/>
	<schemasources>
		<namespaces>
			<nspair prefix="common" uri="http://egov.bg/RegiX/GRAO/NBD"/>
			<nspair prefix="n1" uri="http://egov.bg/RegiX/GRAO/NBD/PersonDataResponse"/>
		</namespaces>
		<schemasources>
			<xsdschemasource name="XML" main="1" schemafile="PersonDataResponse.xsd" workingxmlfile="PersonDataResponse.xml"/>
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
							<template subtype="element" match="n1:PersonDataResponse">
								<children>
									<paragraph paragraphtag="h3">
										<styles text-align="center"/>
										<children>
											<text fixtext="Справка за физическо лице">
												<styles font-weight="bold"/>
											</text>
										</children>
									</paragraph>
									<condition>
										<children>
											<conditionbranch xpath="string-length(.) = 0">
												<children>
													<text fixtext="Не са намерени данни за физическо лице."/>
												</children>
											</conditionbranch>
										</children>
									</condition>
									<tgrid hidecols="when-empty" hiderows="when-empty">
										<properties border="0" width="100%"/>
										<children>
											<tgridbody-cols>
												<children>
													<tgridcol>
														<properties valign="top"/>
														<styles width="1.67in"/>
													</tgridcol>
													<tgridcol>
														<properties valign="top"/>
													</tgridcol>
												</children>
											</tgridbody-cols>
											<tgridbody-rows>
												<children>
													<template subtype="element" match="n1:PersonNames">
														<children>
															<tgridrow>
																<children>
																	<tgridcell>
																		<children>
																			<text fixtext="Имена:">
																				<styles font-weight="bold"/>
																			</text>
																		</children>
																	</tgridcell>
																	<tgridcell>
																		<children>
																			<template subtype="element" match="common:FirstName">
																				<children>
																					<content subtype="regular"/>
																				</children>
																				<variables/>
																			</template>
																			<text fixtext=" "/>
																			<template subtype="element" match="common:SurName">
																				<children>
																					<content subtype="regular"/>
																				</children>
																				<variables/>
																			</template>
																			<text fixtext=" "/>
																			<template subtype="element" match="common:FamilyName">
																				<children>
																					<content subtype="regular"/>
																				</children>
																				<variables/>
																			</template>
																		</children>
																	</tgridcell>
																</children>
															</tgridrow>
														</children>
														<variables/>
													</template>
													<template subtype="element" match="n1:Alias">
														<children>
															<tgridrow>
																<children>
																	<tgridcell>
																		<children>
																			<text fixtext="Псевдоним:">
																				<styles font-weight="bold"/>
																			</text>
																		</children>
																	</tgridcell>
																	<tgridcell>
																		<children>
																			<content subtype="regular"/>
																		</children>
																	</tgridcell>
																</children>
															</tgridrow>
														</children>
														<variables/>
													</template>
													<template subtype="element" match="n1:LatinNames">
														<children>
															<tgridrow conditional-processing="count(common:FirstName)&gt;0 or count(common:SurName)&gt;0 or count(common:FamilyName)&gt;0">
																<children>
																	<tgridcell>
																		<children>
																			<text fixtext="Имена на латиница:">
																				<styles font-weight="bold"/>
																			</text>
																		</children>
																	</tgridcell>
																	<tgridcell>
																		<children>
																			<template subtype="element" match="common:FirstName">
																				<children>
																					<content subtype="regular"/>
																				</children>
																				<variables/>
																			</template>
																			<template subtype="element" match="common:SurName">
																				<children>
																					<text fixtext=" "/>
																					<content subtype="regular"/>
																				</children>
																				<variables/>
																			</template>
																			<template subtype="element" match="common:FamilyName">
																				<children>
																					<text fixtext=" "/>
																					<content subtype="regular"/>
																				</children>
																				<variables/>
																			</template>
																		</children>
																	</tgridcell>
																</children>
															</tgridrow>
														</children>
														<variables/>
													</template>
													<template subtype="element" match="n1:ForeignNames">
														<children>
															<tgridrow conditional-processing="count(common:FirstName)&gt;0 or count(common:SurName)&gt;0 or count(common:FamilyName)&gt;0">
																<children>
																	<tgridcell>
																		<children>
																			<text fixtext="Други известни имена в чужбина:">
																				<styles font-weight="bold"/>
																			</text>
																		</children>
																	</tgridcell>
																	<tgridcell>
																		<children>
																			<template subtype="element" match="common:FirstName">
																				<children>
																					<content subtype="regular"/>
																				</children>
																				<variables/>
																			</template>
																			<template subtype="element" match="common:SurName">
																				<children>
																					<text fixtext=" "/>
																					<content subtype="regular"/>
																				</children>
																				<variables/>
																			</template>
																			<template subtype="element" match="common:FamilyName">
																				<children>
																					<text fixtext=" "/>
																					<content subtype="regular"/>
																				</children>
																				<variables/>
																			</template>
																		</children>
																	</tgridcell>
																</children>
															</tgridrow>
														</children>
														<variables/>
													</template>
													<template subtype="element" match="n1:Gender">
														<children>
															<tgridrow>
																<children>
																	<tgridcell>
																		<children>
																			<text fixtext="Пол:">
																				<styles font-weight="bold"/>
																			</text>
																			<text fixtext=" "/>
																		</children>
																	</tgridcell>
																	<tgridcell>
																		<children>
																			<template subtype="element" match="common:GenderName">
																				<children>
																					<content subtype="regular"/>
																				</children>
																				<variables/>
																			</template>
																		</children>
																	</tgridcell>
																</children>
															</tgridrow>
														</children>
														<variables/>
													</template>
													<template subtype="element" match="n1:EGN">
														<children>
															<tgridrow>
																<children>
																	<tgridcell>
																		<children>
																			<text fixtext="ЕГН:">
																				<styles font-weight="bold"/>
																			</text>
																		</children>
																	</tgridcell>
																	<tgridcell>
																		<children>
																			<content subtype="regular"/>
																		</children>
																	</tgridcell>
																</children>
															</tgridrow>
														</children>
														<variables/>
													</template>
													<template subtype="element" match="n1:BirthDate">
														<children>
															<tgridrow>
																<children>
																	<tgridcell>
																		<children>
																			<text fixtext="Дата на раждане:">
																				<styles font-weight="bold"/>
																			</text>
																			<text fixtext=" "/>
																		</children>
																	</tgridcell>
																	<tgridcell>
																		<children>
																			<content subtype="regular">
																				<format basic-type="xsd" string="DD.MM.YYYY" datatype="date"/>
																			</content>
																		</children>
																	</tgridcell>
																</children>
															</tgridrow>
														</children>
														<variables/>
													</template>
													<template subtype="element" match="n1:PlaceBirth">
														<children>
															<tgridrow>
																<children>
																	<tgridcell>
																		<children>
																			<text fixtext="Място на раждане:">
																				<styles font-weight="bold"/>
																			</text>
																		</children>
																	</tgridcell>
																	<tgridcell>
																		<children>
																			<content subtype="regular">
																				<format basic-type="xsd" datatype="date"/>
																			</content>
																		</children>
																	</tgridcell>
																</children>
															</tgridrow>
														</children>
														<variables/>
													</template>
													<template subtype="element" match="n1:Nationality">
														<children>
															<tgridrow>
																<children>
																	<tgridcell>
																		<children>
																			<text fixtext="Гражданство:">
																				<styles font-weight="bold"/>
																			</text>
																		</children>
																	</tgridcell>
																	<tgridcell>
																		<children>
																			<template subtype="element" match="common:NationalityName">
																				<children>
																					<content subtype="regular"/>
																				</children>
																				<variables/>
																			</template>
																			<template subtype="element" match="common:NationalityName2">
																				<children>
																					<text fixtext=", "/>
																					<content subtype="regular"/>
																				</children>
																				<variables/>
																			</template>
																		</children>
																	</tgridcell>
																</children>
															</tgridrow>
														</children>
														<variables/>
													</template>
													<template subtype="element" match="n1:DeathDate">
														<children>
															<tgridrow>
																<children>
																	<tgridcell>
																		<children>
																			<text fixtext="Дата на смърт:">
																				<styles font-weight="bold"/>
																			</text>
																		</children>
																	</tgridcell>
																	<tgridcell>
																		<children>
																			<content subtype="regular">
																				<format basic-type="xsd" string="DD.MM.YYYY" datatype="date"/>
																			</content>
																		</children>
																	</tgridcell>
																</children>
															</tgridrow>
														</children>
														<variables/>
													</template>
												</children>
											</tgridbody-rows>
										</children>
									</tgrid>
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
