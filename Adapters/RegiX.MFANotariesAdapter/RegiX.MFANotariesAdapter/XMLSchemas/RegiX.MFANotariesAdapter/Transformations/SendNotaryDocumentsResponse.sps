<?xml version="1.0" encoding="UTF-8"?>
<structure version="7" xsltversion="1" cssmode="strict" relativeto="*SPS" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8" embed-images="1">
	<parameters/>
	<schemasources>
		<namespaces>
			<nspair prefix="n1" uri="http://egov.bg/RegiX/MFA/Notaries/SendNotaryDocumentsResponse"/>
		</namespaces>
		<schemasources>
			<xsdschemasource name="$XML" main="1" schemafile="..\SendNotaryDocumentsResponse.xsd" workingxmlfile="..\..\..\XMLSamples\RegiX.MFANotariesAdapter\SendNotaryDocumentsResponse.xml">
				<xmltablesupport/>
				<textstateicons/>
			</xsdschemasource>
		</schemasources>
	</schemasources>
	<modules/>
	<flags>
		<scripts/>
		<globalparts/>
		<designfragments/>
		<pagelayouts/>
	</flags>
	<scripts>
		<script language="javascript"/>
	</scripts>
	<globalstyles/>
	<mainparts>
		<children>
			<globaltemplate match="/" matchtype="named" parttype="main">
				<children>
					<template match="$XML" matchtype="schemasource">
						<editorproperties elementstodisplay="5"/>
						<children>
							<paragraph paragraphtag="h3">
								<properties align="center"/>
								<children>
									<text fixtext="Министерство на външните работи"/>
								</children>
							</paragraph>
							<newline/>
							<paragraph paragraphtag="h2">
								<properties align="center"/>
								<children>
									<text fixtext="Резултат от удостоверяване на заверки"/>
								</children>
							</paragraph>
							<table>
								<properties border="1"/>
								<children>
									<tablebody>
										<children>
											<tablerow>
												<children>
													<tablecell headercell="1">
														<children>
															<text fixtext="Статус"/>
														</children>
													</tablecell>
													<template match="n1:SendNotaryDocumentsResponse" matchtype="schemagraphitem">
														<editorproperties elementstodisplay="5"/>
														<children>
															<tablecell>
																<children>
																	<template match="n1:StatusName" matchtype="schemagraphitem">
																		<editorproperties elementstodisplay="5"/>
																		<children>
																			<content>
																				<format datatype="string"/>
																			</content>
																		</children>
																	</template>
																</children>
															</tablecell>
														</children>
													</template>
												</children>
											</tablerow>
											<tablerow>
												<children>
													<tablecell headercell="1">
														<children>
															<text fixtext="Тип на заверка"/>
														</children>
													</tablecell>
													<template match="n1:SendNotaryDocumentsResponse" matchtype="schemagraphitem">
														<editorproperties elementstodisplay="5"/>
														<children>
															<tablecell>
																<children>
																	<template match="n1:AuthenticationTypeName" matchtype="schemagraphitem">
																		<editorproperties elementstodisplay="5"/>
																		<children>
																			<content>
																				<format datatype="string"/>
																			</content>
																		</children>
																	</template>
																</children>
															</tablecell>
														</children>
													</template>
												</children>
											</tablerow>
											<tablerow>
												<children>
													<tablecell headercell="1">
														<children>
															<text fixtext="Номер на заверка"/>
														</children>
													</tablecell>
													<template match="n1:SendNotaryDocumentsResponse" matchtype="schemagraphitem">
														<editorproperties elementstodisplay="5"/>
														<children>
															<tablecell>
																<children>
																	<template match="n1:AuthenticationNumber" matchtype="schemagraphitem">
																		<editorproperties elementstodisplay="5"/>
																		<children>
																			<content>
																				<format datatype="string"/>
																			</content>
																		</children>
																	</template>
																</children>
															</tablecell>
														</children>
													</template>
												</children>
											</tablerow>
											<tablerow>
												<children>
													<tablecell headercell="1">
														<children>
															<text fixtext="Дата на заверка"/>
														</children>
													</tablecell>
													<template match="n1:SendNotaryDocumentsResponse" matchtype="schemagraphitem">
														<editorproperties elementstodisplay="5"/>
														<children>
															<tablecell>
																<children>
																	<template match="n1:AuthenticationDate" matchtype="schemagraphitem">
																		<editorproperties elementstodisplay="5"/>
																		<children>
																			<content>
																				<format string="DD.MM.YYYY" datatype="date"/>
																			</content>
																			<text fixtext=" г."/>
																		</children>
																	</template>
																</children>
															</tablecell>
														</children>
													</template>
												</children>
											</tablerow>
											<tablerow>
												<children>
													<tablecell headercell="1">
														<children>
															<text fixtext="Консулска служба"/>
														</children>
													</tablecell>
													<template match="n1:SendNotaryDocumentsResponse" matchtype="schemagraphitem">
														<editorproperties elementstodisplay="5"/>
														<children>
															<tablecell>
																<children>
																	<template match="n1:ConsulName" matchtype="schemagraphitem">
																		<editorproperties elementstodisplay="5"/>
																		<children>
																			<content>
																				<format datatype="string"/>
																			</content>
																		</children>
																	</template>
																</children>
															</tablecell>
														</children>
													</template>
												</children>
											</tablerow>
											<tablerow>
												<children>
													<tablecell headercell="1">
														<children>
															<text fixtext="Заявител"/>
														</children>
													</tablecell>
													<template match="n1:SendNotaryDocumentsResponse" matchtype="schemagraphitem">
														<editorproperties elementstodisplay="5"/>
														<children>
															<tablecell>
																<children>
																	<template match="n1:Name" matchtype="schemagraphitem">
																		<editorproperties elementstodisplay="5"/>
																		<children>
																			<content>
																				<format datatype="string"/>
																			</content>
																		</children>
																	</template>
																</children>
															</tablecell>
														</children>
													</template>
												</children>
											</tablerow>
											<tablerow>
												<children>
													<tablecell headercell="1">
														<children>
															<text fixtext="Бележки"/>
														</children>
													</tablecell>
													<template match="n1:SendNotaryDocumentsResponse" matchtype="schemagraphitem">
														<editorproperties elementstodisplay="5"/>
														<children>
															<tablecell>
																<children>
																	<template match="n1:Remarks" matchtype="schemagraphitem">
																		<editorproperties elementstodisplay="5"/>
																		<children>
																			<content>
																				<format datatype="string"/>
																			</content>
																		</children>
																	</template>
																</children>
															</tablecell>
														</children>
													</template>
												</children>
											</tablerow>
											<tablerow>
												<children>
													<tablecell headercell="1">
														<children>
															<text fixtext="Дата на изготвяне на резултат"/>
														</children>
													</tablecell>
													<template match="n1:SendNotaryDocumentsResponse" matchtype="schemagraphitem">
														<editorproperties elementstodisplay="5"/>
														<children>
															<tablecell>
																<children>
																	<template match="n1:ResultDate" matchtype="schemagraphitem">
																		<editorproperties elementstodisplay="5"/>
																		<children>
																			<content>
																				<format string="YYYY&apos;-&apos;MM&apos;-&apos;DD hh:mm:ss &apos;UTC&apos;" datatype="dateTime"/>
																			</content>
																		</children>
																	</template>
																</children>
															</tablecell>
														</children>
													</template>
												</children>
											</tablerow>
											<tablerow>
												<children>
													<tablecell headercell="1">
														<children>
															<text fixtext="Резултат - съобщение"/>
														</children>
													</tablecell>
													<template match="n1:SendNotaryDocumentsResponse" matchtype="schemagraphitem">
														<editorproperties elementstodisplay="5"/>
														<children>
															<tablecell>
																<children>
																	<template match="n1:ResultMessage" matchtype="schemagraphitem">
																		<editorproperties elementstodisplay="5"/>
																		<children>
																			<content>
																				<format datatype="string"/>
																			</content>
																		</children>
																	</template>
																</children>
															</tablecell>
														</children>
													</template>
												</children>
											</tablerow>
											<tablerow>
												<children>
													<tablecell headercell="1">
														<children>
															<text fixtext="Резултат"/>
														</children>
													</tablecell>
													<template match="n1:SendNotaryDocumentsResponse" matchtype="schemagraphitem">
														<editorproperties elementstodisplay="5"/>
														<children>
															<tablecell>
																<children>
																	<template match="n1:Result" matchtype="schemagraphitem">
																		<editorproperties elementstodisplay="5"/>
																		<children>
																			<condition>
																				<children>
																					<conditionbranch xpath=". = &apos;true&apos;">
																						<children>
																							<text fixtext="да"/>
																						</children>
																					</conditionbranch>
																					<conditionbranch xpath=". = &apos;false&apos;">
																						<children>
																							<text fixtext="не"/>
																						</children>
																					</conditionbranch>
																				</children>
																			</condition>
																		</children>
																	</template>
																</children>
															</tablecell>
														</children>
													</template>
												</children>
											</tablerow>
										</children>
									</tablebody>
								</children>
							</table>
						</children>
					</template>
				</children>
			</globaltemplate>
		</children>
	</mainparts>
	<globalparts/>
	<pagelayout/>
	<designfragments/>
</structure>
