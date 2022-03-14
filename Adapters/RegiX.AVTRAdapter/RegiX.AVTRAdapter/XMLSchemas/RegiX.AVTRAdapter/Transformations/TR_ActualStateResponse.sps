<?xml version="1.0" encoding="UTF-8"?>
<structure version="20" xsltversion="1" html-doctype="HTML4 Transitional" compatibility-view="IE9" html-outputextent="Complete" relativeto="*SPS" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8" useimportschema="1" embed-images="1" enable-authentic-scripts="1" authentic-scripts-in-debug-mode-external="0" generated-file-location="DEFAULT">
	<parameters/>
	<schemasources>
		<namespaces>
			<nspair prefix="common" uri="http://egov.bg/RegiX/AV/TR"/>
			<nspair prefix="n1" uri="http://egov.bg/RegiX/AV/TR/ActualStateResponse"/>
		</namespaces>
		<schemasources>
			<xsdschemasource name="XML" main="1" schemafile="D:\Projects\eGov\RegiX\RegiX.AVTRAdapter\XMLSchemas\TR_ActualStateResponse.xsd" workingxmlfile="TR_ActualStateResponse_1.xml"/>
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
							<template subtype="element" match="n1:ActualStateResponse">
								<children>
									<paragraph paragraphtag="h3">
										<properties align="center"/>
										<children>
											<text fixtext="Агенция по вписванията"/>
											<newline/>
											<text fixtext="Търговски регистър"/>
										</children>
									</paragraph>
									<paragraph paragraphtag="h2">
										<properties align="center"/>
										<children>
											<text fixtext="Справка за актуално състояние"/>
										</children>
									</paragraph>
									<condition>
										<children>
											<conditionbranch xpath="string-length(.) &gt; 0">
												<children>
													<template subtype="element" match="n1:Status">
														<children>
															<text fixtext="Статус на партида: "/>
															<content subtype="regular">
																<styles font-weight="bold"/>
															</content>
														</children>
														<variables/>
													</template>
													<template subtype="element" match="n1:LiquidationOrInsolvency">
														<children>
															<newline/>
															<text fixtext="Статус за ликвидация или несъстоятелност: "/>
															<content subtype="regular">
																<styles font-weight="bold"/>
															</content>
														</children>
														<variables/>
													</template>
													<paragraph paragraphtag="h4">
														<children>
															<text fixtext="Основни обстоятелства">
																<styles font-weight="bold"/>
															</text>
														</children>
													</paragraph>
													<template subtype="element" match="n1:UIC">
														<children>
															<text fixtext="1. ЕИК "/>
															<content subtype="regular">
																<styles font-weight="bold"/>
															</content>
														</children>
														<variables/>
													</template>
													<template subtype="element" match="n1:Company">
														<children>
															<newline/>
															<text fixtext="2. Фирма: "/>
															<content subtype="regular">
																<styles font-weight="bold"/>
															</content>
														</children>
														<variables/>
													</template>
													<template subtype="element" match="n1:LegalForm">
														<children>
															<template subtype="element" match="common:LegalFormName">
																<children>
																	<newline/>
																	<text fixtext="3. Правна форма: "/>
																	<content subtype="regular">
																		<styles font-weight="bold"/>
																	</content>
																</children>
																<variables/>
															</template>
														</children>
														<variables/>
													</template>
													<template subtype="element" match="n1:Transliteration">
														<children>
															<newline/>
															<text fixtext="4. Изписване на чужд език: "/>
															<content subtype="regular">
																<styles font-weight="bold"/>
															</content>
														</children>
														<variables/>
													</template>
													<template subtype="element" match="n1:Seat">
														<children>
															<condition>
																<children>
																	<conditionbranch xpath="string-length( common:Address/common:Country )&gt;0 or string-length( common:Address/common:District )&gt;0 or string-length( common:Address/common:Municipality )&gt;0 or string-length( common:Address/common:Settlement )&gt;0 or string-length( common:Address/common:Area )&gt;0 or string-length( common:Address/common:PostCode )&gt;0 or string-length( common:Address/common:ForeignPlace )&gt;0 or string-length( common:Address/common:HousingEstate )&gt;0 or string-length( common:Address/common:Street )&gt;0 or string-length( common:Address/common:StreetNumber )&gt;0 or string-length( common:Address/common:Block )&gt;0 or string-length( common:Address/common:Entrance )&gt;0 or string-length( common:Address/common:Floor )&gt;0 or string-length( common:Address/common:Apartment )&gt;0 or string-length( common:Contacts/common:Phone )&gt;0 or string-length( common:Contacts/common:Fax )&gt;0 or string-length( common:Contacts/common:EMail )&gt;0 or string-length( common:Contacts/common:URL )&gt;0">
																		<children>
																			<newline/>
																			<text fixtext="5. Седалище и адрес на управление:"/>
																		</children>
																	</conditionbranch>
																</children>
															</condition>
															<template subtype="element" match="common:Address">
																<children>
																	<template subtype="element" match="common:Country">
																		<children>
																			<text fixtext=" ">
																				<styles font-weight="bold"/>
																			</text>
																			<content subtype="regular">
																				<styles font-weight="bold"/>
																			</content>
																		</children>
																		<variables/>
																	</template>
																	<text fixtext=" ">
																		<styles font-weight="bold"/>
																	</text>
																	<template subtype="element" match="common:District">
																		<children>
																			<text fixtext=", област ">
																				<styles font-weight="bold"/>
																			</text>
																			<content subtype="regular">
																				<styles font-weight="bold"/>
																			</content>
																		</children>
																		<variables/>
																	</template>
																	<template subtype="element" match="common:Municipality">
																		<children>
																			<text fixtext=", община ">
																				<styles font-weight="bold"/>
																			</text>
																			<content subtype="regular">
																				<styles font-weight="bold"/>
																			</content>
																		</children>
																		<variables/>
																	</template>
																	<template subtype="element" match="common:Settlement">
																		<children>
																			<text fixtext=", ">
																				<styles font-weight="bold"/>
																			</text>
																			<content subtype="regular">
																				<styles font-weight="bold"/>
																			</content>
																		</children>
																		<variables/>
																	</template>
																	<template subtype="element" match="common:PostCode">
																		<children>
																			<text fixtext=" ">
																				<styles font-weight="bold"/>
																			</text>
																			<content subtype="regular">
																				<styles font-weight="bold"/>
																			</content>
																		</children>
																		<variables/>
																	</template>
																	<template subtype="element" match="common:Area">
																		<children>
																			<text fixtext=", ">
																				<styles font-weight="bold"/>
																			</text>
																			<content subtype="regular">
																				<styles font-weight="bold"/>
																			</content>
																		</children>
																		<variables/>
																	</template>
																	<template subtype="element" match="common:ForeignPlace">
																		<children>
																			<text fixtext=", ">
																				<styles font-weight="bold"/>
																			</text>
																			<content subtype="regular">
																				<styles font-weight="bold"/>
																			</content>
																		</children>
																		<variables/>
																	</template>
																	<template subtype="element" match="common:HousingEstate">
																		<children>
																			<text fixtext=", жк. ">
																				<styles font-weight="bold"/>
																			</text>
																			<content subtype="regular">
																				<styles font-weight="bold"/>
																			</content>
																		</children>
																		<variables/>
																	</template>
																	<template subtype="element" match="common:Street">
																		<children>
																			<text fixtext=", ул. ">
																				<styles font-weight="bold"/>
																			</text>
																			<content subtype="regular">
																				<styles font-weight="bold"/>
																			</content>
																		</children>
																		<variables/>
																	</template>
																	<template subtype="element" match="common:StreetNumber">
																		<children>
																			<text fixtext=" ">
																				<styles font-weight="bold"/>
																			</text>
																			<content subtype="regular">
																				<styles font-weight="bold"/>
																			</content>
																		</children>
																		<variables/>
																	</template>
																	<template subtype="element" match="common:Block">
																		<children>
																			<text fixtext=", бл. ">
																				<styles font-weight="bold"/>
																			</text>
																			<content subtype="regular">
																				<styles font-weight="bold"/>
																			</content>
																		</children>
																		<variables/>
																	</template>
																	<template subtype="element" match="common:Entrance">
																		<children>
																			<text fixtext=", вх. ">
																				<styles font-weight="bold"/>
																			</text>
																			<content subtype="regular">
																				<styles font-weight="bold"/>
																			</content>
																		</children>
																		<variables/>
																	</template>
																	<template subtype="element" match="common:Floor">
																		<children>
																			<text fixtext=", ет. ">
																				<styles font-weight="bold"/>
																			</text>
																			<content subtype="regular">
																				<styles font-weight="bold"/>
																			</content>
																		</children>
																		<variables/>
																	</template>
																	<template subtype="element" match="common:Apartment">
																		<children>
																			<text fixtext=", ап. ">
																				<styles font-weight="bold"/>
																			</text>
																			<content subtype="regular">
																				<styles font-weight="bold"/>
																			</content>
																		</children>
																		<variables/>
																	</template>
																</children>
																<variables/>
															</template>
															<template subtype="element" match="common:Contacts">
																<children>
																	<template subtype="element" match="common:Phone">
																		<children>
																			<text fixtext=", тел. ">
																				<styles font-weight="bold"/>
																			</text>
																			<content subtype="regular">
																				<styles font-weight="bold"/>
																			</content>
																		</children>
																		<variables/>
																	</template>
																	<template subtype="element" match="common:Fax">
																		<children>
																			<text fixtext=",факс ">
																				<styles font-weight="bold"/>
																			</text>
																			<content subtype="regular">
																				<styles font-weight="bold"/>
																			</content>
																		</children>
																		<variables/>
																	</template>
																	<template subtype="element" match="common:EMail">
																		<children>
																			<text fixtext=", Електронна поща: ">
																				<styles font-weight="bold"/>
																			</text>
																			<content subtype="regular">
																				<styles font-weight="bold"/>
																			</content>
																		</children>
																		<variables/>
																	</template>
																	<template subtype="element" match="common:URL">
																		<children>
																			<text fixtext=", Интернет страница: ">
																				<styles font-weight="bold"/>
																			</text>
																			<content subtype="regular">
																				<styles font-weight="bold"/>
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
													<template subtype="element" match="n1:SeatForCorrespondence">
														<children>
															<condition>
																<children>
																	<conditionbranch xpath="string-length( common:Country )&gt; 0 or string-length( common:District )&gt;0 or string-length( common:Municipality )&gt;0 or string-length( common:Settlement )&gt;0 or string-length( common:Area )&gt;0 or string-length( common:PostCode )&gt;0 or string-length( common:ForeignPlace )&gt;0 or string-length( common:HousingEstate )&gt;0 or string-length( common:Street )&gt;0 or string-length( common:StreetNumber )&gt;0 or string-length( common:Block )&gt;0 or string-length( common:Entrance )&gt;0 or string-length( common:Floor )&gt;0 or string-length( common:Apartment )&gt;0">
																		<children>
																			<newline/>
																			<text fixtext="5а. Адрес за кореспонденция с НАП на територията на страната:"/>
																		</children>
																	</conditionbranch>
																</children>
															</condition>
															<template subtype="element" match="common:Country">
																<children>
																	<text fixtext=" ">
																		<styles font-weight="bold"/>
																	</text>
																	<content subtype="regular">
																		<styles font-weight="bold"/>
																	</content>
																</children>
																<variables/>
															</template>
															<template subtype="element" match="common:District">
																<children>
																	<text fixtext=", област ">
																		<styles font-weight="bold"/>
																	</text>
																	<content subtype="regular">
																		<styles font-weight="bold"/>
																	</content>
																</children>
																<variables/>
															</template>
															<template subtype="element" match="common:Municipality">
																<children>
																	<text fixtext=", община ">
																		<styles font-weight="bold"/>
																	</text>
																	<content subtype="regular">
																		<styles font-weight="bold"/>
																	</content>
																</children>
																<variables/>
															</template>
															<template subtype="element" match="common:Settlement">
																<children>
																	<text fixtext=", ">
																		<styles font-weight="bold"/>
																	</text>
																	<content subtype="regular">
																		<styles font-weight="bold"/>
																	</content>
																</children>
																<variables/>
															</template>
															<template subtype="element" match="common:PostCode">
																<children>
																	<text fixtext=" ">
																		<styles font-weight="bold"/>
																	</text>
																	<content subtype="regular">
																		<styles font-weight="bold"/>
																	</content>
																</children>
																<variables/>
															</template>
															<template subtype="element" match="common:ForeignPlace">
																<children>
																	<text fixtext=", ">
																		<styles font-weight="bold"/>
																	</text>
																	<content subtype="regular">
																		<styles font-weight="bold"/>
																	</content>
																</children>
																<variables/>
															</template>
															<template subtype="element" match="common:HousingEstate">
																<children>
																	<text fixtext=", жк. ">
																		<styles font-weight="bold"/>
																	</text>
																	<content subtype="regular">
																		<styles font-weight="bold"/>
																	</content>
																</children>
																<variables/>
															</template>
															<template subtype="element" match="common:Street">
																<children>
																	<text fixtext=", ул. ">
																		<styles font-weight="bold"/>
																	</text>
																	<content subtype="regular">
																		<styles font-weight="bold"/>
																	</content>
																</children>
																<variables/>
															</template>
															<template subtype="element" match="common:StreetNumber">
																<children>
																	<text fixtext=" ">
																		<styles font-weight="bold"/>
																	</text>
																	<content subtype="regular">
																		<styles font-weight="bold"/>
																	</content>
																</children>
																<variables/>
															</template>
															<template subtype="element" match="common:Block">
																<children>
																	<text fixtext=", бл. ">
																		<styles font-weight="bold"/>
																	</text>
																	<content subtype="regular">
																		<styles font-weight="bold"/>
																	</content>
																</children>
																<variables/>
															</template>
															<template subtype="element" match="common:Entrance">
																<children>
																	<text fixtext=", вх. ">
																		<styles font-weight="bold"/>
																	</text>
																	<content subtype="regular">
																		<styles font-weight="bold"/>
																	</content>
																</children>
																<variables/>
															</template>
															<template subtype="element" match="common:Floor">
																<children>
																	<text fixtext=", ет. ">
																		<styles font-weight="bold"/>
																	</text>
																	<content subtype="regular">
																		<styles font-weight="bold"/>
																	</content>
																</children>
																<variables/>
															</template>
															<template subtype="element" match="common:Apartment">
																<children>
																	<text fixtext=", ап. ">
																		<styles font-weight="bold"/>
																	</text>
																	<content subtype="regular">
																		<styles font-weight="bold"/>
																	</content>
																</children>
																<variables/>
															</template>
														</children>
														<variables/>
													</template>
													<template subtype="element" match="n1:SubjectOfActivity">
														<children>
															<template subtype="element" match="common:Subject">
																<children>
																	<newline/>
																	<text fixtext="6. Предмет на дейност: "/>
																	<content subtype="regular">
																		<styles font-weight="bold"/>
																	</content>
																</children>
																<variables/>
															</template>
														</children>
														<variables/>
													</template>
													<template subtype="element" match="n1:SubjectOfActivityNKID">
														<children>
															<condition>
																<children>
																	<conditionbranch xpath="string-length(common:NKIDcode)&gt; 0 or string-length( common:NKIDname)&gt;0">
																		<children>
																			<newline/>
																			<text fixtext="6а. Основна  дейност по НКИД: "/>
																		</children>
																	</conditionbranch>
																</children>
															</condition>
															<template subtype="element" match="common:NKIDcode">
																<children>
																	<text fixtext="Код по КИД: ">
																		<styles font-weight="bold"/>
																	</text>
																	<content subtype="regular">
																		<styles font-weight="bold"/>
																	</content>
																</children>
																<variables/>
															</template>
															<template subtype="element" match="common:NKIDname">
																<children>
																	<text fixtext=" Основна икономическа дейност по КИД: ">
																		<styles font-weight="bold"/>
																	</text>
																	<content subtype="regular">
																		<styles font-weight="bold"/>
																	</content>
																</children>
																<variables/>
															</template>
														</children>
														<variables/>
													</template>
													<condition>
														<children>
															<conditionbranch xpath="count(n1:Details/child::common:Detail[common:FieldCode=&apos;7&apos;])&gt;0">
																<children>
																	<newline/>
																	<text fixtext="7. Управители: "/>
																</children>
															</conditionbranch>
														</children>
													</condition>
													<template subtype="element" match="n1:Details">
														<children>
															<template subtype="element" match="common:Detail">
																<children>
																	<condition>
																		<children>
																			<conditionbranch xpath="common:FieldCode = &apos;7&apos;">
																				<children>
																					<template subtype="element" match="common:Subject">
																						<children>
																							<template subtype="element" match="common:Name">
																								<children>
																									<content subtype="regular">
																										<styles font-weight="bold"/>
																									</content>
																								</children>
																								<variables/>
																							</template>
																						</children>
																						<variables/>
																					</template>
																					<condition>
																						<children>
																							<conditionbranch xpath="count(following::common:Detail[common:FieldCode=&apos;7&apos;])&gt;0">
																								<children>
																									<text fixtext=", ">
																										<styles font-weight="bold"/>
																									</text>
																								</children>
																							</conditionbranch>
																						</children>
																					</condition>
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
													<template subtype="element" match="n1:WayOfManagement">
														<children>
															<newline/>
															<text fixtext="8. Начин на управление: "/>
															<content subtype="regular">
																<styles font-weight="bold"/>
															</content>
														</children>
														<variables/>
													</template>
													<condition>
														<children>
															<conditionbranch xpath="count(n1:Details/child::common:Detail[common:FieldCode=&apos;9&apos;])&gt;0">
																<children>
																	<newline/>
																	<text fixtext="9. Председател: "/>
																</children>
															</conditionbranch>
														</children>
													</condition>
													<template subtype="element" match="n1:Details">
														<children>
															<template subtype="element" match="common:Detail">
																<children>
																	<condition>
																		<children>
																			<conditionbranch xpath="common:FieldCode = &apos;9&apos;">
																				<children>
																					<template subtype="element" match="common:Subject">
																						<children>
																							<template subtype="element" match="common:Name">
																								<children>
																									<content subtype="regular"/>
																								</children>
																								<variables/>
																							</template>
																						</children>
																						<variables/>
																					</template>
																					<condition>
																						<children>
																							<conditionbranch xpath="count(following::common:Detail[common:FieldCode=&apos;9&apos;])&gt;0">
																								<children>
																									<text fixtext=", "/>
																								</children>
																							</conditionbranch>
																						</children>
																					</condition>
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
													<condition>
														<children>
															<conditionbranch xpath="count(n1:Details/child::common:Detail[common:FieldCode=&apos;10&apos;])&gt;0">
																<children>
																	<newline/>
																	<text fixtext="10. Представители: "/>
																</children>
															</conditionbranch>
														</children>
													</condition>
													<template subtype="element" match="n1:Details">
														<children>
															<template subtype="element" match="common:Detail">
																<children>
																	<condition>
																		<children>
																			<conditionbranch xpath="common:FieldCode = &apos;10&apos;">
																				<children>
																					<template subtype="element" match="common:Subject">
																						<children>
																							<template subtype="element" match="common:Name">
																								<children>
																									<content subtype="regular">
																										<styles font-weight="bold"/>
																									</content>
																								</children>
																								<variables/>
																							</template>
																						</children>
																						<variables/>
																					</template>
																					<condition>
																						<children>
																							<conditionbranch xpath="count(following::common:Detail[common:FieldCode=&apos;10&apos;])&gt;0">
																								<children>
																									<text fixtext=", ">
																										<styles font-weight="bold"/>
																									</text>
																								</children>
																							</conditionbranch>
																						</children>
																					</condition>
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
													<template subtype="element" match="n1:WayOfRepresentation">
														<children>
															<newline/>
															<text fixtext="11. Начин на представляване: "/>
															<content subtype="regular">
																<styles font-weight="bold"/>
															</content>
														</children>
														<variables/>
													</template>
													<condition>
														<children>
															<conditionbranch xpath="count(n1:Details/child::common:Detail[common:FieldCode=&apos;12&apos;])&gt;0">
																<children>
																	<newline/>
																	<text fixtext="12. Съвет на директорите: "/>
																	<template subtype="element" match="n1:BoardOfDirectorsMandate">
																		<children>
																			<template subtype="element" match="common:MandateValue">
																				<children>
																					<text fixtext=" Дата на изтичане на мандата: ">
																						<styles font-weight="bold"/>
																					</text>
																					<content subtype="regular">
																						<styles font-weight="bold"/>
																					</content>
																					<newline/>
																				</children>
																				<variables/>
																			</template>
																		</children>
																		<variables/>
																	</template>
																</children>
															</conditionbranch>
														</children>
													</condition>
													<template subtype="element" match="n1:Details">
														<children>
															<template subtype="element" match="common:Detail">
																<children>
																	<condition>
																		<children>
																			<conditionbranch xpath="common:FieldCode = &apos;12&apos;">
																				<children>
																					<template subtype="element" match="common:Subject">
																						<children>
																							<template subtype="element" match="common:Name">
																								<children>
																									<content subtype="regular">
																										<styles font-weight="bold"/>
																									</content>
																								</children>
																								<variables/>
																							</template>
																						</children>
																						<variables/>
																					</template>
																					<condition>
																						<children>
																							<conditionbranch xpath="count(following::common:Detail[common:FieldCode=&apos;12&apos;])&gt;0">
																								<children>
																									<text fixtext=", ">
																										<styles font-weight="bold"/>
																									</text>
																								</children>
																							</conditionbranch>
																						</children>
																					</condition>
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
													<condition>
														<children>
															<conditionbranch xpath="count(n1:Details/child::common:Detail[common:FieldCode=&apos;12а&apos;])&gt;0">
																<children>
																	<newline/>
																	<text fixtext="12а. Управителен орган: "/>
																</children>
															</conditionbranch>
														</children>
													</condition>
													<template subtype="element" match="n1:Details">
														<children>
															<template subtype="element" match="common:Detail">
																<children>
																	<condition>
																		<children>
																			<conditionbranch xpath="common:FieldCode = &apos;12а&apos;">
																				<children>
																					<template subtype="element" match="common:Subject">
																						<children>
																							<template subtype="element" match="common:Name">
																								<children>
																									<content subtype="regular">
																										<styles font-weight="bold"/>
																									</content>
																								</children>
																								<variables/>
																							</template>
																						</children>
																						<variables/>
																					</template>
																					<condition>
																						<children>
																							<conditionbranch xpath="count(following::common:Detail[common:FieldCode=&apos;12а&apos;])&gt;0">
																								<children>
																									<text fixtext=", ">
																										<styles font-weight="bold"/>
																									</text>
																								</children>
																							</conditionbranch>
																						</children>
																					</condition>
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
													<condition>
														<children>
															<conditionbranch xpath="count(n1:Details/child::common:Detail[common:FieldCode=&apos;12б&apos;])&gt;0">
																<children>
																	<newline/>
																	<text fixtext="12б. Административен орган: "/>
																	<template subtype="element" match="n1:AdministrativeBoardMandate">
																		<children>
																			<template subtype="element" match="common:MandateValue">
																				<children>
																					<text fixtext="Дата на изтичане на мандата: ">
																						<styles font-weight="bold"/>
																					</text>
																					<content subtype="regular">
																						<styles font-weight="bold"/>
																					</content>
																					<newline/>
																				</children>
																				<variables/>
																			</template>
																		</children>
																		<variables/>
																	</template>
																</children>
															</conditionbranch>
														</children>
													</condition>
													<template subtype="element" match="n1:Details">
														<children>
															<template subtype="element" match="common:Detail">
																<children>
																	<condition>
																		<children>
																			<conditionbranch xpath="common:FieldCode = &apos;12б&apos;">
																				<children>
																					<template subtype="element" match="common:Subject">
																						<children>
																							<template subtype="element" match="common:Name">
																								<children>
																									<content subtype="regular">
																										<styles font-weight="bold"/>
																									</content>
																								</children>
																								<variables/>
																							</template>
																						</children>
																						<variables/>
																					</template>
																					<condition>
																						<children>
																							<conditionbranch xpath="count(following::common:Detail[common:FieldCode=&apos;12б&apos;])&gt;0">
																								<children>
																									<text fixtext=", ">
																										<styles font-weight="bold"/>
																									</text>
																								</children>
																							</conditionbranch>
																						</children>
																					</condition>
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
													<condition>
														<children>
															<conditionbranch xpath="count(n1:Details/child::common:Detail[common:FieldCode=&apos;12в&apos;])&gt;0">
																<children>
																	<newline/>
																	<text fixtext="12в. Заместници на членовете на административния орган: "/>
																</children>
															</conditionbranch>
														</children>
													</condition>
													<template subtype="element" match="n1:Details">
														<children>
															<template subtype="element" match="common:Detail">
																<children>
																	<condition>
																		<children>
																			<conditionbranch xpath="common:FieldCode = &apos;12в&apos;">
																				<children>
																					<template subtype="element" match="common:Subject">
																						<children>
																							<template subtype="element" match="common:Name">
																								<children>
																									<content subtype="regular">
																										<styles font-weight="bold"/>
																									</content>
																								</children>
																								<variables/>
																							</template>
																						</children>
																						<variables/>
																					</template>
																					<condition>
																						<children>
																							<conditionbranch xpath="count(following::common:Detail[common:FieldCode=&apos;12в&apos;])&gt;0">
																								<children>
																									<text fixtext=", ">
																										<styles font-weight="bold"/>
																									</text>
																								</children>
																							</conditionbranch>
																						</children>
																					</condition>
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
													<condition>
														<children>
															<conditionbranch xpath="count(n1:Details/child::common:Detail[common:FieldCode=&apos;13&apos;])&gt;0">
																<children>
																	<newline/>
																	<text fixtext="13. Управителен съвет: "/>
																	<template subtype="element" match="n1:BoardOfManagersMandate">
																		<children>
																			<template subtype="element" match="common:MandateValue">
																				<children>
																					<text fixtext="Дата на изтичане на мандата: ">
																						<styles font-weight="bold"/>
																					</text>
																					<content subtype="regular">
																						<styles font-weight="bold"/>
																					</content>
																					<newline/>
																				</children>
																				<variables/>
																			</template>
																		</children>
																		<variables/>
																	</template>
																</children>
															</conditionbranch>
														</children>
													</condition>
													<template subtype="element" match="n1:Details">
														<children>
															<template subtype="element" match="common:Detail">
																<children>
																	<condition>
																		<children>
																			<conditionbranch xpath="common:FieldCode = &apos;13&apos;">
																				<children>
																					<template subtype="element" match="common:Subject">
																						<children>
																							<template subtype="element" match="common:Name">
																								<children>
																									<content subtype="regular">
																										<styles font-weight="bold"/>
																									</content>
																								</children>
																								<variables/>
																							</template>
																						</children>
																						<variables/>
																					</template>
																					<condition>
																						<children>
																							<conditionbranch xpath="count(following::common:Detail[common:FieldCode=&apos;13&apos;])&gt;0">
																								<children>
																									<text fixtext=", ">
																										<styles font-weight="bold"/>
																									</text>
																								</children>
																							</conditionbranch>
																						</children>
																					</condition>
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
													<condition>
														<children>
															<conditionbranch xpath="count(n1:Details/child::common:Detail[common:FieldCode=&apos;13а&apos;])&gt;0">
																<children>
																	<newline/>
																	<text fixtext="13а. Подгласници в управителния  съвет: "/>
																</children>
															</conditionbranch>
														</children>
													</condition>
													<template subtype="element" match="n1:Details">
														<children>
															<template subtype="element" match="common:Detail">
																<children>
																	<condition>
																		<children>
																			<conditionbranch xpath="common:FieldCode = &apos;13а&apos;">
																				<children>
																					<template subtype="element" match="common:Subject">
																						<children>
																							<template subtype="element" match="common:Name">
																								<children>
																									<content subtype="regular">
																										<styles font-weight="bold"/>
																									</content>
																								</children>
																								<variables/>
																							</template>
																						</children>
																						<variables/>
																					</template>
																					<condition>
																						<children>
																							<conditionbranch xpath="count(following::common:Detail[common:FieldCode=&apos;13а&apos;])&gt;0">
																								<children>
																									<text fixtext=", ">
																										<styles font-weight="bold"/>
																									</text>
																								</children>
																							</conditionbranch>
																						</children>
																					</condition>
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
													<condition>
														<children>
															<conditionbranch xpath="count(n1:Details/child::common:Detail[common:FieldCode=&apos;13б&apos;])&gt;0">
																<children>
																	<newline/>
																	<text fixtext="13б. Ръководен орган: "/>
																	<template subtype="element" match="n1:BoardOfManagers2Mandate">
																		<children>
																			<template subtype="element" match="common:MandateValue">
																				<children>
																					<text fixtext="Дата на изтичане на мандата: ">
																						<styles font-weight="bold"/>
																					</text>
																					<content subtype="regular">
																						<styles font-weight="bold"/>
																					</content>
																					<newline/>
																				</children>
																				<variables/>
																			</template>
																		</children>
																		<variables/>
																	</template>
																</children>
															</conditionbranch>
														</children>
													</condition>
													<template subtype="element" match="n1:Details">
														<children>
															<template subtype="element" match="common:Detail">
																<children>
																	<condition>
																		<children>
																			<conditionbranch xpath="common:FieldCode = &apos;13б&apos;">
																				<children>
																					<template subtype="element" match="common:Subject">
																						<children>
																							<template subtype="element" match="common:Name">
																								<children>
																									<content subtype="regular">
																										<styles font-weight="bold"/>
																									</content>
																								</children>
																								<variables/>
																							</template>
																						</children>
																						<variables/>
																					</template>
																					<condition>
																						<children>
																							<conditionbranch xpath="count(following::common:Detail[common:FieldCode=&apos;13б&apos;])&gt;0">
																								<children>
																									<text fixtext=", ">
																										<styles font-weight="bold"/>
																									</text>
																								</children>
																							</conditionbranch>
																						</children>
																					</condition>
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
													<condition>
														<children>
															<conditionbranch xpath="count(n1:Details/child::common:Detail[common:FieldCode=&apos;13в&apos;])&gt;0">
																<children>
																	<newline/>
																	<text fixtext="13в. Заместници на членовете на управителния орган: "/>
																	<template subtype="element" match="n1:LeadingBoardMandate">
																		<children>
																			<template subtype="element" match="common:MandateValue">
																				<children>
																					<text fixtext="Дата на изтичане на мандата: ">
																						<styles font-weight="bold"/>
																					</text>
																					<content subtype="regular">
																						<styles font-weight="bold"/>
																					</content>
																					<newline/>
																				</children>
																				<variables/>
																			</template>
																		</children>
																		<variables/>
																	</template>
																</children>
															</conditionbranch>
														</children>
													</condition>
													<template subtype="element" match="n1:Details">
														<children>
															<template subtype="element" match="common:Detail">
																<children>
																	<condition>
																		<children>
																			<conditionbranch xpath="common:FieldCode = &apos;13в&apos;">
																				<children>
																					<template subtype="element" match="common:Subject">
																						<children>
																							<template subtype="element" match="common:Name">
																								<children>
																									<content subtype="regular">
																										<styles font-weight="bold"/>
																									</content>
																								</children>
																								<variables/>
																							</template>
																						</children>
																						<variables/>
																					</template>
																					<condition>
																						<children>
																							<conditionbranch xpath="count(following::common:Detail[common:FieldCode=&apos;13в&apos;])&gt;0">
																								<children>
																									<text fixtext=", ">
																										<styles font-weight="bold"/>
																									</text>
																								</children>
																							</conditionbranch>
																						</children>
																					</condition>
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
													<condition>
														<children>
															<conditionbranch xpath="count(n1:Details/child::common:Detail[common:FieldCode=&apos;14&apos;])&gt;0">
																<children>
																	<newline/>
																	<text fixtext="14. Надзорен съвет: "/>
																	<template subtype="element" match="n1:SupervisingBoardMandate">
																		<children>
																			<template subtype="element" match="common:MandateValue">
																				<children>
																					<text fixtext="Дата на изтичане на мандата: ">
																						<styles font-weight="bold"/>
																					</text>
																					<content subtype="regular">
																						<styles font-weight="bold"/>
																					</content>
																					<newline/>
																				</children>
																				<variables/>
																			</template>
																		</children>
																		<variables/>
																	</template>
																</children>
															</conditionbranch>
														</children>
													</condition>
													<template subtype="element" match="n1:Details">
														<children>
															<template subtype="element" match="common:Detail">
																<children>
																	<condition>
																		<children>
																			<conditionbranch xpath="common:FieldCode = &apos;14&apos;">
																				<children>
																					<template subtype="element" match="common:Subject">
																						<children>
																							<template subtype="element" match="common:Name">
																								<children>
																									<content subtype="regular">
																										<styles font-weight="bold"/>
																									</content>
																								</children>
																								<variables/>
																							</template>
																						</children>
																						<variables/>
																					</template>
																					<condition>
																						<children>
																							<conditionbranch xpath="count(following::common:Detail[common:FieldCode=&apos;14&apos;])&gt;0">
																								<children>
																									<text fixtext=", ">
																										<styles font-weight="bold"/>
																									</text>
																								</children>
																							</conditionbranch>
																						</children>
																					</condition>
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
													<condition>
														<children>
															<conditionbranch xpath="count(n1:Details/child::common:Detail[common:FieldCode=&apos;14б&apos;])&gt;0">
																<children>
																	<newline/>
																	<text fixtext="14б. Надзорен орган: "/>
																	<template subtype="element" match="n1:SupervisingBoard2Mandate">
																		<children>
																			<template subtype="element" match="common:MandateValue">
																				<children>
																					<text fixtext="Дата на изтичане на мандата: ">
																						<styles font-weight="bold"/>
																					</text>
																					<content subtype="regular">
																						<styles font-weight="bold"/>
																					</content>
																					<newline/>
																				</children>
																				<variables/>
																			</template>
																		</children>
																		<variables/>
																	</template>
																</children>
															</conditionbranch>
														</children>
													</condition>
													<template subtype="element" match="n1:Details">
														<children>
															<template subtype="element" match="common:Detail">
																<children>
																	<condition>
																		<children>
																			<conditionbranch xpath="common:FieldCode = &apos;14б&apos;">
																				<children>
																					<template subtype="element" match="common:Subject">
																						<children>
																							<template subtype="element" match="common:Name">
																								<children>
																									<content subtype="regular">
																										<styles font-weight="bold"/>
																									</content>
																								</children>
																								<variables/>
																							</template>
																						</children>
																						<variables/>
																					</template>
																					<condition>
																						<children>
																							<conditionbranch xpath="count(following::common:Detail[common:FieldCode=&apos;14б&apos;])&gt;0">
																								<children>
																									<text fixtext=", ">
																										<styles font-weight="bold"/>
																									</text>
																								</children>
																							</conditionbranch>
																						</children>
																					</condition>
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
													<condition>
														<children>
															<conditionbranch xpath="count(n1:Details/child::common:Detail[common:FieldCode=&apos;14в&apos;])&gt;0">
																<children>
																	<newline/>
																	<text fixtext="14в. Заместници на членовете на надзорния орган: "/>
																</children>
															</conditionbranch>
														</children>
													</condition>
													<template subtype="element" match="n1:Details">
														<children>
															<template subtype="element" match="common:Detail">
																<children>
																	<condition>
																		<children>
																			<conditionbranch xpath="common:FieldCode = &apos;14в&apos;">
																				<children>
																					<template subtype="element" match="common:Subject">
																						<children>
																							<template subtype="element" match="common:Name">
																								<children>
																									<content subtype="regular">
																										<styles font-weight="bold"/>
																									</content>
																								</children>
																								<variables/>
																							</template>
																						</children>
																						<variables/>
																					</template>
																					<condition>
																						<children>
																							<conditionbranch xpath="count(following::common:Detail[common:FieldCode=&apos;14в&apos;])&gt;0">
																								<children>
																									<text fixtext=", ">
																										<styles font-weight="bold"/>
																									</text>
																								</children>
																							</conditionbranch>
																						</children>
																					</condition>
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
													<condition>
														<children>
															<conditionbranch xpath="count(n1:Details/child::common:Detail[common:FieldCode=&apos;15&apos;])&gt;0">
																<children>
																	<newline/>
																	<text fixtext="15. Контролен съвет: "/>
																	<template subtype="element" match="n1:ControllingBoardMandate">
																		<children>
																			<template subtype="element" match="common:MandateValue">
																				<children>
																					<text fixtext="Дата на изтичане на мандата: ">
																						<styles font-weight="bold"/>
																					</text>
																					<content subtype="regular">
																						<styles font-weight="bold"/>
																					</content>
																					<newline/>
																				</children>
																				<variables/>
																			</template>
																		</children>
																		<variables/>
																	</template>
																</children>
															</conditionbranch>
														</children>
													</condition>
													<template subtype="element" match="n1:Details">
														<children>
															<template subtype="element" match="common:Detail">
																<children>
																	<condition>
																		<children>
																			<conditionbranch xpath="common:FieldCode = &apos;15&apos;">
																				<children>
																					<template subtype="element" match="common:Subject">
																						<children>
																							<template subtype="element" match="common:Name">
																								<children>
																									<content subtype="regular">
																										<styles font-weight="bold"/>
																									</content>
																								</children>
																								<variables/>
																							</template>
																						</children>
																						<variables/>
																					</template>
																					<condition>
																						<children>
																							<conditionbranch xpath="count(following::common:Detail[common:FieldCode=&apos;15&apos;])&gt;0">
																								<children>
																									<text fixtext=", ">
																										<styles font-weight="bold"/>
																									</text>
																								</children>
																							</conditionbranch>
																						</children>
																					</condition>
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
													<condition>
														<children>
															<conditionbranch xpath="count(n1:Details/child::common:Detail[common:FieldCode=&apos;15а&apos;])&gt;0">
																<children>
																	<newline/>
																	<text fixtext="15а. Подгласници в контролния  съвет: "/>
																</children>
															</conditionbranch>
														</children>
													</condition>
													<template subtype="element" match="n1:Details">
														<children>
															<template subtype="element" match="common:Detail">
																<children>
																	<condition>
																		<children>
																			<conditionbranch xpath="common:FieldCode = &apos;15а&apos;">
																				<children>
																					<template subtype="element" match="common:Subject">
																						<children>
																							<template subtype="element" match="common:Name">
																								<children>
																									<content subtype="regular">
																										<styles font-weight="bold"/>
																									</content>
																								</children>
																								<variables/>
																							</template>
																						</children>
																						<variables/>
																					</template>
																					<condition>
																						<children>
																							<conditionbranch xpath="count(following::common:Detail[common:FieldCode=&apos;15а&apos;])&gt;0">
																								<children>
																									<text fixtext=", ">
																										<styles font-weight="bold"/>
																									</text>
																								</children>
																							</conditionbranch>
																						</children>
																					</condition>
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
													<template subtype="element" match="n1:TermsOfPartnership">
														<children>
															<newline/>
															<text fixtext="16. Срок на дружеството: "/>
															<content subtype="regular">
																<styles font-weight="bold"/>
															</content>
														</children>
														<variables/>
													</template>
													<template subtype="element" match="n1:TermOfExisting">
														<children>
															<newline/>
															<text fixtext="16а. Срок на съществуване: "/>
															<content subtype="regular">
																<styles font-weight="bold"/>
															</content>
														</children>
														<variables/>
													</template>
													<template subtype="element" match="n1:SpecialConditions">
														<children>
															<newline/>
															<text fixtext="17. Специални условия: "/>
															<content subtype="regular">
																<styles font-weight="bold"/>
															</content>
														</children>
														<variables/>
													</template>
													<condition>
														<children>
															<conditionbranch xpath="count(n1:Details/child::common:Detail[common:FieldCode=&apos;20&apos;])&gt;0">
																<children>
																	<newline/>
																	<text fixtext="20. Неограничено отговорни съдружници: "/>
																</children>
															</conditionbranch>
														</children>
													</condition>
													<template subtype="element" match="n1:Details">
														<children>
															<template subtype="element" match="common:Detail">
																<children>
																	<condition>
																		<children>
																			<conditionbranch xpath="common:FieldCode = &apos;20&apos;">
																				<children>
																					<template subtype="element" match="common:Subject">
																						<children>
																							<template subtype="element" match="common:Name">
																								<children>
																									<content subtype="regular">
																										<styles font-weight="bold"/>
																									</content>
																								</children>
																								<variables/>
																							</template>
																						</children>
																						<variables/>
																					</template>
																					<condition>
																						<children>
																							<conditionbranch xpath="count(following::common:Detail[common:FieldCode=&apos;20&apos;])&gt;0">
																								<children>
																									<text fixtext=", ">
																										<styles font-weight="bold"/>
																									</text>
																								</children>
																							</conditionbranch>
																						</children>
																					</condition>
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
													<condition>
														<children>
															<conditionbranch xpath="count(n1:Details/child::common:Detail[common:FieldCode=&apos;23&apos;])&gt;0">
																<children>
																	<newline/>
																	<text fixtext="23. Едноличен собственик на капитала: "/>
																</children>
															</conditionbranch>
														</children>
													</condition>
													<template subtype="element" match="n1:Details">
														<children>
															<template subtype="element" match="common:Detail">
																<children>
																	<condition>
																		<children>
																			<conditionbranch xpath="common:FieldCode = &apos;23&apos;">
																				<children>
																					<template subtype="element" match="common:Subject">
																						<children>
																							<template subtype="element" match="common:Name">
																								<children>
																									<content subtype="regular">
																										<styles font-weight="bold"/>
																									</content>
																								</children>
																								<variables/>
																							</template>
																						</children>
																						<variables/>
																					</template>
																					<condition>
																						<children>
																							<conditionbranch xpath="count(following::common:Detail[common:FieldCode=&apos;23&apos;])&gt;0">
																								<children>
																									<text fixtext=", ">
																										<styles font-weight="bold"/>
																									</text>
																								</children>
																							</conditionbranch>
																						</children>
																					</condition>
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
													<condition>
														<children>
															<conditionbranch xpath="count(n1:Details/child::common:Detail[common:FieldCode=&apos;23а&apos;])&gt;0">
																<children>
																	<newline/>
																	<text fixtext="23а. Собственик: "/>
																</children>
															</conditionbranch>
														</children>
													</condition>
													<template subtype="element" match="n1:Details">
														<children>
															<template subtype="element" match="common:Detail">
																<children>
																	<condition>
																		<children>
																			<conditionbranch xpath="common:FieldCode = &apos;23а&apos;">
																				<children>
																					<template subtype="element" match="common:Subject">
																						<children>
																							<template subtype="element" match="common:Name">
																								<children>
																									<content subtype="regular">
																										<styles font-weight="bold"/>
																									</content>
																								</children>
																								<variables/>
																							</template>
																						</children>
																						<variables/>
																					</template>
																					<condition>
																						<children>
																							<conditionbranch xpath="count(following::common:Detail[common:FieldCode=&apos;23а&apos;])&gt;0">
																								<children>
																									<text fixtext=", ">
																										<styles font-weight="bold"/>
																									</text>
																								</children>
																							</conditionbranch>
																						</children>
																					</condition>
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
													<condition>
														<children>
															<conditionbranch xpath="count(n1:Details/child::common:Detail[common:FieldCode=&apos;23б&apos;])&gt;0">
																<children>
																	<newline/>
																	<text fixtext="23б. Холдингово европейско дружество като акционер: "/>
																</children>
															</conditionbranch>
														</children>
													</condition>
													<template subtype="element" match="n1:Details">
														<children>
															<template subtype="element" match="common:Detail">
																<children>
																	<condition>
																		<children>
																			<conditionbranch xpath="common:FieldCode = &apos;23б&apos;">
																				<children>
																					<template subtype="element" match="common:Subject">
																						<children>
																							<template subtype="element" match="common:Name">
																								<children>
																									<content subtype="regular">
																										<styles font-weight="bold"/>
																									</content>
																								</children>
																								<variables/>
																							</template>
																						</children>
																						<variables/>
																					</template>
																					<condition>
																						<children>
																							<conditionbranch xpath="count(following::common:Detail[common:FieldCode=&apos;23б&apos;])&gt;0">
																								<children>
																									<text fixtext=", ">
																										<styles font-weight="bold"/>
																									</text>
																								</children>
																							</conditionbranch>
																						</children>
																					</condition>
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
													<template subtype="element" match="n1:HiddenNonMonetaryDeposit">
														<children>
															<newline/>
															<text fixtext="24а. Скрита непарична вноска: "/>
															<content subtype="regular">
																<styles font-weight="bold"/>
															</content>
														</children>
														<variables/>
													</template>
													<template subtype="element" match="n1:SharePaymentResponsibility">
														<children>
															<newline/>
															<text fixtext="25. Отговорност над дялови вноски: "/>
															<content subtype="regular">
																<styles font-weight="bold"/>
															</content>
														</children>
														<variables/>
													</template>
													<template subtype="element" match="n1:ConcededEstateValue">
														<children>
															<newline/>
															<text fixtext="25а. Стойност на имуществото, предоставено от държавата или общината: "/>
															<content subtype="regular">
																<styles font-weight="bold"/>
															</content>
														</children>
														<variables/>
													</template>
													<template subtype="element" match="n1:CessationOfTrade">
														<children>
															<newline/>
															<text fixtext="26. Прекратяване на търговската дейност: "/>
															<content subtype="regular">
																<styles font-weight="bold"/>
															</content>
														</children>
														<variables/>
													</template>
													<template subtype="element" match="n1:AddemptionOfTrader">
														<children>
															<newline/>
															<text fixtext="27. Заличаване на търговеца: "/>
															<content subtype="regular">
																<styles font-weight="bold"/>
															</content>
														</children>
														<variables/>
													</template>
													<condition>
														<children>
															<conditionbranch xpath="string-length(n1:AddemptionOfTraderSeatChange/common:Address/common:Country)&gt; 0 or string-length( n1:AddemptionOfTraderSeatChange/common:Address/common:District )&gt; 0 or string-length( n1:AddemptionOfTraderSeatChange/common:Address/common:Municipality )&gt;0 or string-length( n1:AddemptionOfTraderSeatChange/common:Address/common:Settlement )&gt;0 or string-length( n1:AddemptionOfTraderSeatChange/common:Address/common:Area )&gt;0 or string-length( n1:AddemptionOfTraderSeatChange/common:Address/common:PostCode )&gt;0 or string-length( n1:AddemptionOfTraderSeatChange/common:Address/common:ForeignPlace )&gt;0 or string-length( n1:AddemptionOfTraderSeatChange/common:Address/common:HousingEstate )&gt;0 or string-length( n1:AddemptionOfTraderSeatChange/common:Address/common:Street )&gt;0 or string-length( n1:AddemptionOfTraderSeatChange/common:Address/common:StreetNumber )&gt;0 or string-length( n1:AddemptionOfTraderSeatChange/common:Address/common:Block )&gt;0 or string-length( n1:AddemptionOfTraderSeatChange/common:Address/common:Entrance )&gt;0 or string-length( n1:AddemptionOfTraderSeatChange/common:Address/common:Floor )&gt;0 or string-length( n1:AddemptionOfTraderSeatChange/common:Address/common:Apartment )&gt;0 or string-length( n1:AddemptionOfTraderSeatChange/common:Contacts/common:Phone )&gt;0 or string-length( n1:AddemptionOfTraderSeatChange/common:Contacts/common:Fax )&gt;0 or string-length( n1:AddemptionOfTraderSeatChange/common:Contacts/common:EMail )&gt;0 or string-length( n1:AddemptionOfTraderSeatChange/common:Contacts/common:URL )&gt;0 or string-length( n1:AddemptionOfTraderSeatChange/common:CompetentAuthorityForRegistration )&gt;0 or string-length( n1:AddemptionOfTraderSeatChange/common:RegistrationNumber )&gt;0">
																<children>
																	<newline/>
																	<text fixtext="27а. Заличаване поради преместване на седалището в друга дъжвава-членка: "/>
																	<template subtype="element" match="n1:AddemptionOfTraderSeatChange">
																		<children>
																			<template subtype="element" match="common:RegistrationNumber">
																				<children>
																					<text fixtext="номер: ">
																						<styles font-weight="bold"/>
																					</text>
																					<content subtype="regular">
																						<styles font-weight="bold"/>
																					</content>
																					<text fixtext=" ">
																						<styles font-weight="bold"/>
																					</text>
																				</children>
																				<variables/>
																			</template>
																			<template subtype="element" match="common:CompetentAuthorityForRegistration">
																				<children>
																					<content subtype="regular">
																						<styles font-weight="bold"/>
																					</content>
																				</children>
																				<variables/>
																			</template>
																			<template subtype="element" match="common:Address">
																				<children>
																					<text fixtext=" Адрес: ">
																						<styles font-weight="bold"/>
																					</text>
																					<template subtype="element" match="common:Country">
																						<children>
																							<content subtype="regular">
																								<styles font-weight="bold"/>
																							</content>
																						</children>
																						<variables/>
																					</template>
																					<template subtype="element" match="common:District">
																						<children>
																							<text fixtext=", област ">
																								<styles font-weight="bold"/>
																							</text>
																							<content subtype="regular">
																								<styles font-weight="bold"/>
																							</content>
																						</children>
																						<variables/>
																					</template>
																					<template subtype="element" match="common:Municipality">
																						<children>
																							<text fixtext=", община ">
																								<styles font-weight="bold"/>
																							</text>
																							<content subtype="regular">
																								<styles font-weight="bold"/>
																							</content>
																						</children>
																						<variables/>
																					</template>
																					<template subtype="element" match="common:Settlement">
																						<children>
																							<text fixtext=", ">
																								<styles font-weight="bold"/>
																							</text>
																							<content subtype="regular">
																								<styles font-weight="bold"/>
																							</content>
																						</children>
																						<variables/>
																					</template>
																					<template subtype="element" match="common:PostCode">
																						<children>
																							<text fixtext=" ">
																								<styles font-weight="bold"/>
																							</text>
																							<content subtype="regular">
																								<styles font-weight="bold"/>
																							</content>
																						</children>
																						<variables/>
																					</template>
																					<template subtype="element" match="common:ForeignPlace">
																						<children>
																							<text fixtext=", ">
																								<styles font-weight="bold"/>
																							</text>
																							<content subtype="regular">
																								<styles font-weight="bold"/>
																							</content>
																						</children>
																						<variables/>
																					</template>
																					<template subtype="element" match="common:Area">
																						<children>
																							<text fixtext=", ">
																								<styles font-weight="bold"/>
																							</text>
																							<content subtype="regular">
																								<styles font-weight="bold"/>
																							</content>
																						</children>
																						<variables/>
																					</template>
																					<template subtype="element" match="common:HousingEstate">
																						<children>
																							<text fixtext=", жк. ">
																								<styles font-weight="bold"/>
																							</text>
																							<content subtype="regular">
																								<styles font-weight="bold"/>
																							</content>
																						</children>
																						<variables/>
																					</template>
																					<template subtype="element" match="common:Street">
																						<children>
																							<text fixtext=",ул. ">
																								<styles font-weight="bold"/>
																							</text>
																							<content subtype="regular">
																								<styles font-weight="bold"/>
																							</content>
																						</children>
																						<variables/>
																					</template>
																					<template subtype="element" match="common:StreetNumber">
																						<children>
																							<text fixtext=" ">
																								<styles font-weight="bold"/>
																							</text>
																							<content subtype="regular">
																								<styles font-weight="bold"/>
																							</content>
																						</children>
																						<variables/>
																					</template>
																					<template subtype="element" match="common:Block">
																						<children>
																							<text fixtext=", бл. ">
																								<styles font-weight="bold"/>
																							</text>
																							<content subtype="regular">
																								<styles font-weight="bold"/>
																							</content>
																						</children>
																						<variables/>
																					</template>
																					<template subtype="element" match="common:Entrance">
																						<children>
																							<text fixtext=", вх. ">
																								<styles font-weight="bold"/>
																							</text>
																							<content subtype="regular">
																								<styles font-weight="bold"/>
																							</content>
																						</children>
																						<variables/>
																					</template>
																					<template subtype="element" match="common:Floor">
																						<children>
																							<text fixtext=", ет. ">
																								<styles font-weight="bold"/>
																							</text>
																							<content subtype="regular">
																								<styles font-weight="bold"/>
																							</content>
																						</children>
																						<variables/>
																					</template>
																					<template subtype="element" match="common:Apartment">
																						<children>
																							<text fixtext=", ап. ">
																								<styles font-weight="bold"/>
																							</text>
																							<content subtype="regular">
																								<styles font-weight="bold"/>
																							</content>
																						</children>
																						<variables/>
																					</template>
																				</children>
																				<variables/>
																			</template>
																			<template subtype="element" match="common:Contacts">
																				<children>
																					<template subtype="element" match="common:Phone">
																						<children>
																							<text fixtext=", тел. ">
																								<styles font-weight="bold"/>
																							</text>
																							<content subtype="regular">
																								<styles font-weight="bold"/>
																							</content>
																						</children>
																						<variables/>
																					</template>
																					<template subtype="element" match="common:Fax">
																						<children>
																							<text fixtext=", факс ">
																								<styles font-weight="bold"/>
																							</text>
																							<content subtype="regular">
																								<styles font-weight="bold"/>
																							</content>
																						</children>
																						<variables/>
																					</template>
																					<template subtype="element" match="common:EMail">
																						<children>
																							<text fixtext=", Електронна поща: ">
																								<styles font-weight="bold"/>
																							</text>
																							<content subtype="regular">
																								<styles font-weight="bold"/>
																							</content>
																						</children>
																						<variables/>
																					</template>
																					<template subtype="element" match="common:URL">
																						<children>
																							<text fixtext=", Интернет страница: ">
																								<styles font-weight="bold"/>
																							</text>
																							<content subtype="regular">
																								<styles font-weight="bold"/>
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
															</conditionbranch>
														</children>
													</condition>
													<newline/>
													<paragraph paragraphtag="h4">
														<children>
															<text fixtext="Капитал">
																<styles font-weight="bold"/>
															</text>
														</children>
													</paragraph>
													<template subtype="element" match="n1:Funds">
														<children>
															<template subtype="element" match="common:Value">
																<children>
																	<newline/>
																	<text fixtext="31. Размер: "/>
																	<content subtype="regular">
																		<styles font-weight="bold"/>
																	</content>
																	<text fixtext=" лв.">
																		<styles font-weight="bold"/>
																	</text>
																</children>
																<variables/>
															</template>
														</children>
														<variables/>
													</template>
													<condition>
														<children>
															<conditionbranch xpath="count( n1:Shares/common:Share )&gt;0">
																<children>
																	<newline/>
																	<text fixtext="31а. Акции:"/>
																</children>
															</conditionbranch>
														</children>
													</condition>
													<template subtype="element" match="n1:Shares">
														<children>
															<template subtype="element" match="common:Share">
																<children>
																	<template subtype="element" match="common:Type">
																		<children>
																			<text fixtext=" Вид: ">
																				<styles font-weight="bold"/>
																			</text>
																			<content subtype="regular">
																				<styles font-weight="bold"/>
																			</content>
																		</children>
																		<variables/>
																	</template>
																	<template subtype="element" match="common:Count">
																		<children>
																			<text fixtext=", Брой: ">
																				<styles font-weight="bold"/>
																			</text>
																			<content subtype="regular">
																				<styles font-weight="bold"/>
																			</content>
																		</children>
																		<variables/>
																	</template>
																	<template subtype="element" match="common:NominalValue">
																		<children>
																			<text fixtext=", Номинал: ">
																				<styles font-weight="bold"/>
																			</text>
																			<content subtype="regular">
																				<styles font-weight="bold"/>
																			</content>
																			<text fixtext=" лв.">
																				<styles font-weight="bold"/>
																			</text>
																		</children>
																		<variables/>
																	</template>
																	<condition>
																		<children>
																			<conditionbranch xpath="count(following::common:Share)&gt;0">
																				<children>
																					<text fixtext="; ">
																						<styles font-weight="bold"/>
																					</text>
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
													<template subtype="element" match="n1:MinimumAmount">
														<children>
															<template subtype="element" match="common:Value">
																<children>
																	<newline/>
																	<text fixtext="31б. Минимален размер: "/>
																	<content subtype="regular">
																		<styles font-weight="bold"/>
																	</content>
																</children>
																<variables/>
															</template>
														</children>
														<variables/>
													</template>
													<template subtype="element" match="n1:DepositedFunds">
														<children>
															<template subtype="element" match="common:Value">
																<children>
																	<newline/>
																	<text fixtext="32. Внесен капитал: "/>
																	<content subtype="regular">
																		<styles font-weight="bold"/>
																	</content>
																	<text fixtext=" лв.">
																		<styles font-weight="bold"/>
																	</text>
																</children>
																<variables/>
															</template>
														</children>
														<variables/>
													</template>
													<condition>
														<children>
															<conditionbranch xpath="count(n1:NonMonetaryDeposits/common:NonMonetaryDeposit)&gt;0">
																<children>
																	<newline/>
																	<text fixtext="33. Непарична вноска: "/>
																</children>
															</conditionbranch>
														</children>
													</condition>
													<template subtype="element" match="n1:NonMonetaryDeposits">
														<children>
															<template subtype="element" match="common:NonMonetaryDeposit">
																<children>
																	<template subtype="element" match="common:Description">
																		<children>
																			<text fixtext="Описание: ">
																				<styles font-weight="bold"/>
																			</text>
																			<content subtype="regular">
																				<styles font-weight="bold"/>
																			</content>
																		</children>
																		<variables/>
																	</template>
																	<template subtype="element" match="common:Value">
																		<children>
																			<text fixtext=", Стойност: ">
																				<styles font-weight="bold"/>
																			</text>
																			<content subtype="regular">
																				<styles font-weight="bold"/>
																			</content>
																			<text fixtext=" лв.">
																				<styles font-weight="bold"/>
																			</text>
																		</children>
																		<variables/>
																	</template>
																	<condition>
																		<children>
																			<conditionbranch xpath="count(following::common:NonMonetaryDeposit)&gt;0">
																				<children>
																					<text fixtext="; ">
																						<styles font-weight="bold"/>
																					</text>
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
													<template subtype="element" match="n1:BuyBackDecision">
														<children>
															<newline/>
															<text fixtext="34. Решение за обратно изкупуване на акции: "/>
															<content subtype="regular">
																<styles font-weight="bold"/>
															</content>
														</children>
														<variables/>
													</template>
												</children>
											</conditionbranch>
											<conditionbranch>
												<children>
													<text fixtext="Не са намерени данни в регистъра по зададените критерии за търсене."/>
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
			</globaltemplate>
		</children>
	</mainparts>
	<globalparts/>
	<designfragments/>
	<xmltables/>
	<authentic-custom-toolbar-buttons/>
</structure>
