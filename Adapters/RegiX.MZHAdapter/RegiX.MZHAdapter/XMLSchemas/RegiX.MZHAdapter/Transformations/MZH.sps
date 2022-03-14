<?xml version="1.0" encoding="UTF-8"?>
<structure version="16" xsltversion="1" html-doctype="HTML4 Transitional" compatibility-view="IE9" relativeto="*SPS" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8" useimportschema="1" embed-images="1" enable-authentic-scripts="1" authentic-scripts-in-debug-mode-external="0" generated-file-location="DEFAULT">
	<parameters/>
	<schemasources>
		<namespaces>
			<nspair prefix="common" uri="http://egov.bg/RegiX/MZH"/>
			<nspair prefix="n1" uri="http://egov.bg/RegiX/MZH/FarmerSearchResponse"/>
		</namespaces>
		<schemasources>
			<xsdschemasource name="XML" main="1" schemafile="FarmerSearchResponse.xsd" workingxmlfile="MZHData_2.xml"/>
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
							<template subtype="element" match="n1:Farmer">
								<children>
									<paragraph paragraphtag="h3">
										<styles text-align="center"/>
										<children>
											<text fixtext="Справка за земеделски производител"/>
										</children>
									</paragraph>
									<paragraph paragraphtag="p">
										<children>
											<template subtype="element" match="n1:AdministrativeData">
												<children>
													<paragraph paragraphtag="h4">
														<children>
															<text fixtext="Административни данни за регистрирания земеделски производител"/>
														</children>
													</paragraph>
													<list>
														<properties start="0"/>
														<children>
															<template subtype="element" match="common:Entity">
																<children>
																	<template subtype="element" match="common:CompanyName">
																		<children>
																			<listrow>
																				<children>
																					<text fixtext="Наименование:"/>
																					<content subtype="regular"/>
																				</children>
																			</listrow>
																		</children>
																		<variables/>
																	</template>
																</children>
																<variables/>
															</template>
														</children>
													</list>
													<condition>
														<children>
															<conditionbranch xpath="string-length(common:Person/common:Name)&gt;0 or string-length(common:Person/common:Surname)&gt;0 or string-length(common:Person/common:Family)&gt;0">
																<children>
																	<list>
																		<properties start="0"/>
																		<children>
																			<template subtype="element" match="common:Person">
																				<children>
																					<listrow>
																						<children>
																							<text fixtext="Имена: "/>
																							<template subtype="element" match="common:Name">
																								<children>
																									<content subtype="regular"/>
																								</children>
																								<variables/>
																							</template>
																							<template subtype="element" match="common:Surname">
																								<children>
																									<text fixtext=" "/>
																									<content subtype="regular"/>
																								</children>
																								<variables/>
																							</template>
																							<template subtype="element" match="common:Family">
																								<children>
																									<text fixtext=" "/>
																									<content subtype="regular"/>
																								</children>
																								<variables/>
																							</template>
																						</children>
																					</listrow>
																				</children>
																				<variables/>
																			</template>
																		</children>
																	</list>
																</children>
															</conditionbranch>
														</children>
													</condition>
													<list>
														<properties start="0"/>
														<children>
															<template subtype="element" match="common:ActiveRegistration">
																<children>
																	<template subtype="element" match="common:RegistrationDate">
																		<children>
																			<listrow>
																				<children>
																					<text fixtext="Дата на регистрация: "/>
																					<content subtype="regular">
																						<format basic-type="xsd" string="DD.MM.YYYY" datatype="date"/>
																					</content>
																				</children>
																			</listrow>
																		</children>
																		<variables/>
																	</template>
																</children>
																<variables/>
															</template>
														</children>
													</list>
													<list>
														<properties start="0"/>
														<children>
															<template subtype="element" match="common:CancelledRegistration">
																<children>
																	<template subtype="element" match="common:CancelledDate">
																		<children>
																			<listrow>
																				<children>
																					<text fixtext="Дата на отписване: "/>
																					<content subtype="regular">
																						<format basic-type="xsd" string="DD.MM.YYYY" datatype="date"/>
																					</content>
																				</children>
																			</listrow>
																		</children>
																		<variables/>
																	</template>
																</children>
																<variables/>
															</template>
														</children>
													</list>
												</children>
												<variables/>
											</template>
										</children>
									</paragraph>
									<paragraph paragraphtag="p">
										<children>
											<template subtype="element" match="n1:Lands">
												<children>
													<paragraph paragraphtag="h4">
														<children>
															<text fixtext="Данни за използвани земеделски земи"/>
														</children>
													</paragraph>
													<tgrid>
														<properties border="1"/>
														<styles border-collapse="collapse"/>
														<children>
															<tgridbody-cols>
																<children>
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
																					<text fixtext="ЕКАТТЕ на землище"/>
																				</children>
																			</tgridcell>
																			<tgridcell>
																				<children>
																					<text fixtext="Обработвана земя общо"/>
																				</children>
																			</tgridcell>
																		</children>
																	</tgridrow>
																</children>
															</tgridheader-rows>
															<tgridbody-rows>
																<children>
																	<template subtype="element" match="common:Land">
																		<children>
																			<tgridrow>
																				<children>
																					<tgridcell>
																						<children>
																							<template subtype="element" match="common:EKKATE">
																								<children>
																									<content subtype="regular">
																										<format basic-type="xsd" datatype="double"/>
																									</content>
																								</children>
																								<variables/>
																							</template>
																						</children>
																					</tgridcell>
																					<tgridcell>
																						<children>
																							<template subtype="element" match="common:Infield">
																								<children>
																									<content subtype="regular">
																										<format basic-type="xsd" datatype="double"/>
																									</content>
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
																</children>
															</tgridbody-rows>
														</children>
													</tgrid>
												</children>
												<variables/>
											</template>
										</children>
									</paragraph>
									<template subtype="element" match="n1:Crops">
										<children>
											<paragraph paragraphtag="p">
												<children>
													<condition>
														<children>
															<conditionbranch xpath="count(common:Crop)">
																<children>
																	<paragraph paragraphtag="h4">
																		<children>
																			<text fixtext="Данни за отглеждани култури"/>
																		</children>
																	</paragraph>
																	<tgrid>
																		<properties border="1"/>
																		<styles border-collapse="collapse"/>
																		<children>
																			<tgridbody-cols>
																				<children>
																					<tgridcol/>
																					<tgridcol/>
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
																									<paragraph paragraphtag="p">
																										<children>
																											<text fixtext="ЕКАТТЕ на землище"/>
																										</children>
																									</paragraph>
																								</children>
																							</tgridcell>
																							<tgridcell>
																								<children>
																									<paragraph paragraphtag="p">
																										<children>
																											<text fixtext="Код на културата"/>
																										</children>
																									</paragraph>
																								</children>
																							</tgridcell>
																							<tgridcell>
																								<children>
																									<paragraph paragraphtag="p">
																										<children>
																											<text fixtext="Вид на културата"/>
																										</children>
																									</paragraph>
																								</children>
																							</tgridcell>
																							<tgridcell>
																								<children>
																									<paragraph paragraphtag="p">
																										<children>
																											<text fixtext="Засети площи (за текуща стопанска година)"/>
																										</children>
																									</paragraph>
																								</children>
																							</tgridcell>
																							<tgridcell>
																								<children>
																									<paragraph paragraphtag="p">
																										<children>
																											<text fixtext="Намерения за засети площи (за следваща стопанска година)"/>
																										</children>
																									</paragraph>
																								</children>
																							</tgridcell>
																						</children>
																					</tgridrow>
																				</children>
																			</tgridheader-rows>
																			<tgridbody-rows>
																				<children>
																					<template subtype="element" match="common:Crop">
																						<children>
																							<tgridrow>
																								<children>
																									<tgridcell>
																										<children>
																											<template subtype="element" match="common:EKKATE">
																												<children>
																													<content subtype="regular"/>
																												</children>
																												<variables/>
																											</template>
																										</children>
																									</tgridcell>
																									<tgridcell>
																										<children>
																											<template subtype="element" match="common:CropCode">
																												<children>
																													<content subtype="regular">
																														<format basic-type="xsd" datatype="int"/>
																													</content>
																												</children>
																												<variables/>
																											</template>
																										</children>
																									</tgridcell>
																									<tgridcell>
																										<children>
																											<template subtype="element" match="common:CropName">
																												<children>
																													<content subtype="regular"/>
																												</children>
																												<variables/>
																											</template>
																										</children>
																									</tgridcell>
																									<tgridcell>
																										<children>
																											<template subtype="element" match="common:SownArea">
																												<children>
																													<content subtype="regular">
																														<format basic-type="xsd" datatype="double"/>
																													</content>
																												</children>
																												<variables/>
																											</template>
																										</children>
																									</tgridcell>
																									<tgridcell>
																										<children>
																											<template subtype="element" match="common:IntendedSownAreaNextYear">
																												<children>
																													<content subtype="regular">
																														<format basic-type="xsd" datatype="double"/>
																													</content>
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
																				</children>
																			</tgridbody-rows>
																		</children>
																	</tgrid>
																</children>
															</conditionbranch>
														</children>
													</condition>
												</children>
											</paragraph>
										</children>
										<variables/>
									</template>
									<template subtype="element" match="n1:Animals">
										<children>
											<condition>
												<children>
													<conditionbranch xpath="count(common:Animal)&gt;0">
														<children>
															<paragraph paragraphtag="p">
																<children>
																	<paragraph paragraphtag="h4">
																		<children>
																			<text fixtext="Данни за отглеждани животни"/>
																			<newline/>
																		</children>
																	</paragraph>
																	<tgrid>
																		<properties border="1"/>
																		<styles border-collapse="collapse"/>
																		<children>
																			<tgridbody-cols>
																				<children>
																					<tgridcol/>
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
																									<text fixtext="ЕКАТТЕ на землище"/>
																								</children>
																							</tgridcell>
																							<tgridcell>
																								<children>
																									<text fixtext="Код на категория животни"/>
																								</children>
																							</tgridcell>
																							<tgridcell>
																								<children>
																									<text fixtext="Вид и категория животни"/>
																								</children>
																							</tgridcell>
																							<tgridcell>
																								<children>
																									<text fixtext="Брой животни"/>
																								</children>
																							</tgridcell>
																						</children>
																					</tgridrow>
																				</children>
																			</tgridheader-rows>
																			<tgridbody-rows>
																				<children>
																					<template subtype="element" match="common:Animal">
																						<children>
																							<tgridrow>
																								<children>
																									<tgridcell>
																										<children>
																											<template subtype="element" match="common:EKKATE">
																												<children>
																													<content subtype="regular"/>
																												</children>
																												<variables/>
																											</template>
																										</children>
																									</tgridcell>
																									<tgridcell>
																										<children>
																											<template subtype="element" match="common:AnimalCode">
																												<children>
																													<content subtype="regular">
																														<format basic-type="xsd" datatype="int"/>
																													</content>
																												</children>
																												<variables/>
																											</template>
																										</children>
																									</tgridcell>
																									<tgridcell>
																										<children>
																											<template subtype="element" match="common:AnimalName">
																												<children>
																													<content subtype="regular"/>
																												</children>
																												<variables/>
																											</template>
																										</children>
																									</tgridcell>
																									<tgridcell>
																										<children>
																											<template subtype="element" match="common:Units">
																												<children>
																													<content subtype="regular">
																														<format basic-type="xsd" datatype="int"/>
																													</content>
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
																				</children>
																			</tgridbody-rows>
																		</children>
																	</tgrid>
																</children>
															</paragraph>
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
